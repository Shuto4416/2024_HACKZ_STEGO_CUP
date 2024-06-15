using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayFabTest : MonoBehaviour
{
    public static Dictionary<string, string> SaveDatas = new Dictionary<string, string>();
    public static Dictionary<string, string> DecodingDatas = new Dictionary<string, string>();

    public void Login()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "235DD";
        }
        SaveCustomId();
        var request = new LoginWithCustomIDRequest { CustomId = CustomId, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    const string PLAYFAB_CUSTOM_ID = "PLAYFAB_CUSTOM_ID";
    public static string CustomId { get => PlayerPrefs.GetString(PLAYFAB_CUSTOM_ID, Guid.NewGuid().ToString()); }

    public void SaveCustomId()
    {
        PlayerPrefs.SetString(PLAYFAB_CUSTOM_ID, CustomId);
        PlayerPrefs.Save();
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("PlayFab : Connected");
        GetUserData(result.PlayFabId);
        
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("PlayFab : Login Error");
        Debug.LogError(error.GenerateErrorReport());
    }

    void SetUserData()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() {
            {"positionX", transform.position.x.ToString("G9")},
            {"positionY", transform.position.y.ToString("G9")},
            {"positionZ", transform.position.z.ToString("G9")}
            }
        },
        result => Debug.Log("PlayFab : Successfully updated user data"),
        error => {
            Debug.Log("PlayFab : Got error setting user data Ancestor to Arthur");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    Dictionary<string,UserDataRecord> GetUserData(string myPlayFabId)
    {
        Dictionary<string, UserDataRecord> returnData = null;
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myPlayFabId,
            Keys = null
        }, result => {
            Debug.Log("PlayFab : Got user data");
            foreach (var entry in result.Data)
            {
                Debug.Log("    " + entry.Key + ": " + entry.Value.Value);
            }
            if (result.Data == null || !result.Data.ContainsKey("positionX") || !result.Data.ContainsKey("positionY") || !result.Data.ContainsKey("positionZ")) Debug.Log("No data");
            else
            {
                Vector3 pos = new Vector3(float.Parse(result.Data["positionX"].Value), float.Parse(result.Data["positionY"].Value), float.Parse(result.Data["positionZ"].Value));
                transform.position = pos;
            }
            returnData = result.Data;
        }, (error) => {
            Debug.Log("PlayFab : Got error retrieving user data");
            Debug.Log(error.GenerateErrorReport());
        });
        return returnData;
    }
}