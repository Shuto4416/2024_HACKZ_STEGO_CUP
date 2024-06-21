using UnityEngine;
using System.Threading.Tasks;
using Assets.MyAssets.InGame.Slimes;
using Assets.MyAssets.MakeSlime;
using Assets.MyAssets.MakeSlime.Inputs;
using R3;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class MakeSlime : MonoBehaviour
    {
        private IMakeSlimeInputEventProvider _makeSlimeInputEvent;
        private ReelData _reelData;
        
        void Start()
        {
            _makeSlimeInputEvent = this.gameObject.GetComponent<IMakeSlimeInputEventProvider>();
            _reelData = this.gameObject.GetComponent<ReelData>();

            _makeSlimeInputEvent.DecideButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    var data = _reelData.GetReelSlimeParametersData();
                    PassMakeSlimeToInGame(data.Weight, data.Size, data.Viscosity, _reelData.GetReelSpecialTypesData());
                });
            
        }
        
        public async void PassMakeSlimeToInGame(float weight,float size, float viscosity, SpecialTypes specialTypes)
        {
            await Task.Delay(3000);
            var nextScene = await SceneLoader.Load<InGame>("InGame");
            nextScene.SetArguments(weight,size,viscosity,specialTypes);
        }
    }
}