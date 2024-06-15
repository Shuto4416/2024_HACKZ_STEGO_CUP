using UnityEngine;
using System.Threading.Tasks;
using Assets.MyAssets.InGame.Slimes;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class MakeSlime : MonoBehaviour
    {
        public async void PassMakeSlimeToInGame(float weight,float size, float viscosity, SpecialTypes specialTypes)
        {
            await Task.Delay(3000);
            var nextScene = await SceneLoader.Load<InGame>("InGame");
            nextScene.SetArguments(weight,size,viscosity,specialTypes);
        }
    }
}