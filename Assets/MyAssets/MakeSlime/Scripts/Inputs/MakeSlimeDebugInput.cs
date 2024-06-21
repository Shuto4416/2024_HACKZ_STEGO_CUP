using System;
using Assets.MyAssets.MakeSlime.Inputs;
using R3;
using R3.Triggers;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes.Inputs
{
    public class MakeSlimeDebugInput : MonoBehaviour,IMakeSlimeInputEventProvider
    {
        private ReactiveProperty<bool> _upButton = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> _downButton = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> _rightButton = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> _leftButton = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> _decideButton = new ReactiveProperty<bool>(false);
        private ReactiveProperty<bool> _returnButton = new ReactiveProperty<bool>(false);

        public ReadOnlyReactiveProperty<bool> UpButton
        {
            get { return _upButton; }
        }

        public ReadOnlyReactiveProperty<bool> DownButton
        {
            get { return _downButton; }
        }

        public ReadOnlyReactiveProperty<bool> RightButton
        {
            get { return _rightButton; }
        }

        public ReadOnlyReactiveProperty<bool> LeftButton
        {
            get { return _leftButton; }
        }

        public ReadOnlyReactiveProperty<bool> DecideButton
        {
            get { return _decideButton; }
        }

        public ReadOnlyReactiveProperty<bool> ReturnButton
        {
            get { return _returnButton; }
        }

        void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.W))
                .DistinctUntilChanged()
                .Subscribe(x => _upButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.S))
                .DistinctUntilChanged()
                .Subscribe(x => _downButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.D))
                .DistinctUntilChanged()
                .Subscribe(x => _rightButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.A))
                .DistinctUntilChanged()
                .Subscribe(x => _leftButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Space))
                .DistinctUntilChanged()
                .Subscribe(x => _decideButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Escape))
                .DistinctUntilChanged()
                .Subscribe(x => _returnButton.Value = x);
        }
    }
}
