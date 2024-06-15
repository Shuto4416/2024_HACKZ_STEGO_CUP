using UnityEngine;
using System.Threading.Tasks;
using Assets.MyAssets.InGame.Slimes;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class InGame : MonoBehaviour
    {
        public void SetArguments(float weight,float size, float viscosity, SpecialTypes specialTypes)
        {
            
        }
        
        public async void PassMakeSlimeToInGame(string gameData)
        {
            await Task.Delay(3000);
            var nextScene = await SceneLoader.Load<Result>("Result");
            nextScene.SetArguments(gameData);
        }
    }
}
