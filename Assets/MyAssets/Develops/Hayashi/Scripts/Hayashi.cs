using System.Threading.Tasks;
using Assets.MyAssets.Common.Scripts;
using Assets.MyAssets.Common.Scripts.Scenes;
using UnityEngine;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class Hayashi : MonoBehaviour
    {
        async void Start()
        {
            await Task.Delay(5000);
            PassMakeSlimeToInGame("hoge");
        }
        public async void PassMakeSlimeToInGame(string hoge)
        {
            await Task.Delay(3000);
            var nextScene = await SceneLoader.Load<ITI>("ITI");
            nextScene.SetArguments("死になさい");
        }
    }
}