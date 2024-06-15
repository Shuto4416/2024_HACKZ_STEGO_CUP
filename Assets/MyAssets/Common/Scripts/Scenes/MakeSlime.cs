using UnityEngine;
using System.Threading.Tasks;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class MakeSlime : MonoBehaviour
    {
        public async void PassMainToGameOver()
        {
            await Task.Delay(3000);
            //var sceneB = await SceneLoader.Load<GameOver>("GameOver");
            //sceneB.SetArguments(battleGameManager.enemyKillNum - 1, charaName);
        }
    }
}