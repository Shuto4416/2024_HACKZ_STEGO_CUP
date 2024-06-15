using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    public class SlimeSpecial : BaseSlimeComponent
    {
        [SerializeField]
        private List<GameObject> _slimeSpecials;

        [SerializeField] 
        private Transform _slimeTransform;
        
        protected override void OnInitialize()
        {
            InGameInputEventProvider.OnSpecialButtonPushed
                .Where(x => x)
                .Skip(1)
                .Subscribe(_ =>
                {
                    Instantiate(_slimeSpecials[(int)(SlimeCore.SpecialTypes)], _slimeTransform.position, Quaternion.identity);
                });
        }
    }
}
