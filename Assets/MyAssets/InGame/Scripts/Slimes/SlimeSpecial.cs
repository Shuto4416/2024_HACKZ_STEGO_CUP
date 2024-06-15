using System;
using System.Collections.Generic;
using Assets.MyAssets.InGame.Slimes.Specials;
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
        
        private float _xDirection = 1f;
        
        protected override void OnInitialize()
        {
            InGameInputEventProvider.MoveDirection
                .Where(x => x.x != 0)
                .Subscribe(x => _xDirection = x.x);
            
            _canSpecial = true;
            InGameInputEventProvider.OnSpecialButtonPushed
                .Where(x => x && _canSpecial)
                .Skip(1)
                .Subscribe(_ =>
                {
                    GameObject specialObject = Instantiate(_slimeSpecials[(int)(SlimeCore.SpecialTypes)], _slimeTransform.position, Quaternion.identity);
                    specialObject.transform.localScale *= CurrentPlayerParameter.CurrentValue.Size;
                    
                    specialObject.GetComponent<BaseSpecial>().OnInitialize(_xDirection);
                    _canSpecial = false;
                    
                    Observable.Timer(TimeSpan.FromSeconds(SlimeCore.SpecialTypes.ToWaitSeconds()))
                        .Subscribe(_ => _canSpecial = true);
                });
        }
    }
}
