using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayFabDataManager
{
    private static PlayFabDataManager instance;
    private TaskCompletionSource<bool> loginTaskCompletionSource = new TaskCompletionSource<bool>();

    public static PlayFabDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayFabDataManager();
            }
            return instance;
        }
    }

    private PlayFabDataManager()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "235DD";
        }
        SaveCustomGuid();
        var request = new LoginWithCustomIDRequest { CustomId = CustomId, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private string playFabId;

    const string PLAYFAB_CUSTOM_ID = "PLAYFAB_CUSTOM_ID";
    public static string CustomId { get => PlayerPrefs.GetString(PLAYFAB_CUSTOM_ID, Guid.NewGuid().ToString()); }

    private void SaveCustomGuid()
    {
        PlayerPrefs.SetString(PLAYFAB_CUSTOM_ID, CustomId);
        PlayerPrefs.Save();
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("PlayFab : Connected");
        playFabId = result.PlayFabId;
        loginTaskCompletionSource.SetResult(true);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("PlayFab : Login Error");
        loginTaskCompletionSource.SetResult(false);
    }

    public void SetUserData(string text)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() { { "string", text } }
        },
        result => Debug.Log("PlayFab : Successfully updated user data"),
        error =>
        {
            Debug.Log("PlayFab : Got error setting user data");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    /// <summary>
    /// égópó·ÅFpublic async void OnGet()
    ///{
    ///     inputField.text = await PlayFabDataManager.Instance.GetUserData();
    ///}
    /// </summary>
    /// <returns></returns>
public async Task<string> GetUserData()
    {
        await EnsureLoggedInAsync();
        return await GetUserData(playFabId);
    }

    public async Task<string> GetUserData(string myPlayFabId)
    {
        await EnsureLoggedInAsync();

        var tcs = new TaskCompletionSource<Dictionary<string, UserDataRecord>>();

        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myPlayFabId,
            Keys = null
        },
        result =>
        {
            Debug.Log("PlayFab : Got user data");
            foreach (var entry in result.Data)
            {
                Debug.Log("    " + entry.Key + ": " + entry.Value.Value);
            }
            tcs.SetResult(result.Data);
        },
        error =>
        {
            Debug.Log("PlayFab : Got error retrieving user data");
            Debug.Log(error.GenerateErrorReport());
            tcs.SetResult(null);
        });

        var returnData = await tcs.Task;
        if (returnData == null || !returnData.ContainsKey("string"))
        {
            Debug.Log("No data");
            return "";
        }
        return returnData["string"].Value;
    }

    private async Task EnsureLoggedInAsync()
    {
        if (!loginTaskCompletionSource.Task.IsCompleted)
        {
            await loginTaskCompletionSource.Task;
        }
    }
}
