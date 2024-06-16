using Assets.MyAssets.MakeSlime.Inputs;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyAssets.MakeSlime
{
    public class ParameterUI : MonoBehaviour
    {
        private IMakeSlimeInputEventProvider _makeSlimeInputEvent;
        private ReelData _reelData;
        [SerializeField]
        private Text _text;
        
        void Start()
        {
            _makeSlimeInputEvent = this.gameObject.GetComponent<IMakeSlimeInputEventProvider>();
            _reelData = this.gameObject.GetComponent<ReelData>();
            
            _text.text = $"大きさ : {_reelData.GetReelSlimeParametersData().Size}\n重さ : {_reelData.GetReelSlimeParametersData().Weight}\n粘着度 : {_reelData.GetReelSlimeParametersData().Viscosity}\n属性 : {_reelData.GetReelSpecialTypesData()}\n";
            
            _makeSlimeInputEvent.UpButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _text.text = $"大きさ : {_reelData.GetReelSlimeParametersData().Size}\n重さ : {_reelData.GetReelSlimeParametersData().Weight}\n粘着度 : {_reelData.GetReelSlimeParametersData().Viscosity}\n属性 : {_reelData.GetReelSpecialTypesData()}\n";
                });
            
            _makeSlimeInputEvent.DownButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _text.text = $"大きさ : {_reelData.GetReelSlimeParametersData().Size}\n重さ : {_reelData.GetReelSlimeParametersData().Weight}\n粘着度 : {_reelData.GetReelSlimeParametersData().Viscosity}\n属性 : {_reelData.GetReelSpecialTypesData()}\n";
                });
        }
    }
}