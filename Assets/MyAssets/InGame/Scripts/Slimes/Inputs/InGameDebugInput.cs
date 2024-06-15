using System;
using UnityEngine;
using R3;
using R3.Triggers;

namespace Assets.MyAssets.InGame.Slimes.Inputs
{
    /// <summary>
    /// インゲームのデバック環境の入力
    /// </summary>
    public class InGameDebugInput : MonoBehaviour
    {
        private ReactiveProperty<int> _xMoveDirection = new ReactiveProperty<int>();
        private ReactiveProperty<bool> _onSpecialButtonPushed = new ReactiveProperty<bool>();
        private ReactiveProperty<bool> _onJumpButtonPushed = new ReactiveProperty<bool>();
        private ReactiveProperty<bool> _pauseButton = new ReactiveProperty<bool>();

        ReadOnlyReactiveProperty<int> XMoveDirection { get { return _xMoveDirection; } }
        ReadOnlyReactiveProperty<bool> OnSpecialButtonPushed { get { return _onSpecialButtonPushed; } }
        ReadOnlyReactiveProperty<bool> OnJumpButtonPushed { get { return _onJumpButtonPushed; } }
        ReadOnlyReactiveProperty<bool> PauseButton { get { return _pauseButton; } }
        
        void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => _xMoveDirection.OnNext(Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A))));

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.E))
                .DistinctUntilChanged()
                .Subscribe(x => _onSpecialButtonPushed.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Space))
                .DistinctUntilChanged()
                .Subscribe(x => _onJumpButtonPushed.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Escape))
                .DistinctUntilChanged()
                .Subscribe(x => _pauseButton.Value = x);

            XMoveDirection.Subscribe(_ => Debug.Log($"XMove : {XMoveDirection.CurrentValue}"));
            OnSpecialButtonPushed.Subscribe(_ => Debug.Log($"Special : {OnSpecialButtonPushed.CurrentValue}"));
            OnJumpButtonPushed.Subscribe(_ => Debug.Log($"Jump : {OnJumpButtonPushed.CurrentValue}"));
            PauseButton.Subscribe(_ => Debug.Log($"Pause : {PauseButton.CurrentValue}"));
        }
    }
}