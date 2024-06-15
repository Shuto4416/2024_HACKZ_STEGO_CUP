using System;
using UnityEngine;
using R3;
using R3.Triggers;

namespace Assets.MyAssets.InGame.Slimes.Inputs
{
    /// <summary>
    /// インゲームのデバック環境の入力
    /// </summary>
    public class InGameDebugInput : MonoBehaviour, IInGameInputEventProvider
    {
        private ReactiveProperty<Vector2> _moveDirection = new ReactiveProperty<Vector2>();
        private ReactiveProperty<bool> _onSpecialButtonPushed = new ReactiveProperty<bool>();
        private ReactiveProperty<bool> _pauseButton = new ReactiveProperty<bool>();

        public ReadOnlyReactiveProperty<Vector2> MoveDirection { get { return _moveDirection; } }
        public ReadOnlyReactiveProperty<bool> OnSpecialButtonPushed { get { return _onSpecialButtonPushed; } }
        public ReadOnlyReactiveProperty<bool> PauseButton { get { return _pauseButton; } }
        
        void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => _moveDirection.OnNext(new Vector2(
                    Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A)), 
                    Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S))
                    )));

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Space))
                .DistinctUntilChanged()
                .Subscribe(x => _onSpecialButtonPushed.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Escape))
                .DistinctUntilChanged()
                .Subscribe(x => _pauseButton.Value = x);
        }
    }
}