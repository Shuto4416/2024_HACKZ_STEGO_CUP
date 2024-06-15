using System;
using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeの移動制御クラス
    /// </summary>
    public class SlimeController : BaseSlimeComponent
    {
        ReactiveProperty<bool> _isRunning = new ReactiveProperty<bool>();
        ReactiveProperty<bool> _isOnAir = new ReactiveProperty<bool>();
        ReactiveProperty<bool> _isJumping = new ReactiveProperty<bool>();

        
        private SlimeMover _slimeMover;
        private bool isFreezed;

        public ReadOnlyReactiveProperty<bool> IsRunning { get { return _isRunning; } }
        public ReadOnlyReactiveProperty<bool> IsOnAir { get { return _isOnAir; } }
        public ReadOnlyReactiveProperty<bool> IsJumping { get { return _isJumping; } }

        protected override void OnInitialize()
        {
            
        }

        protected override void OnStart()
        {
            _slimeMover = GetComponent<SlimeMover>();

            InGameInputEventProvider.MoveDirection
                .Where(_ => !(InGameInputEventProvider.MoveDirection.CurrentValue.normalized == new Vector2(0f, 0f)))
                .Subscribe(_ =>
                {
                    _slimeMover.Move(InGameInputEventProvider.MoveDirection.CurrentValue, 10f);
                });
            
        }
    }
}