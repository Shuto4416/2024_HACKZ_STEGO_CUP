using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeのスペシャル攻撃
    /// </summary>
    public class SlimeSpecial : BaseSlimeComponent
    {
        [SerializeField]
        private List<GameObject> _slimeSpecials;

        [SerializeField] 
        private Transform _slimeTransform;

        private bool _canSpecial;
        
        protected override void OnInitialize()
        {
            _canSpecial = true;
            InGameInputEventProvider.OnSpecialButtonPushed
                .Where(x => x && _canSpecial)
                .Skip(1)
                .Subscribe(_ =>
                {
                    Instantiate(_slimeSpecials[(int)(SlimeCore.SpecialTypes)], _slimeTransform.position, Quaternion.identity);

                    _canSpecial = false;
                    
                    Observable.Timer(TimeSpan.FromSeconds(SlimeCore.SpecialTypes.ToWaitSeconds()))
                        .Subscribe(_ => _canSpecial = true);
                });
        }
    }
}
