using System;
using R3;
using R3.Triggers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    public class SlimeCore : MonoBehaviour
    {
        private ReactiveProperty<bool> _isDamaged = new ReactiveProperty<bool>(false);
        public ReadOnlyReactiveProperty<bool> IsDamaged { get { return _isDamaged; } }
        
        /*
        private IGameStateProvider gameStateProvider;

        public IReadOnlyReactiveProperty<GameState> CurrentGameState
        {
            get { return gameStateProvider.CurrentGameState; }
        }
        */
        
        private SlimeParameters DefaultSlimeParameter;
        private ReactiveProperty<SlimeParameters> _currentSlimeParameter;

        /// <summary>
        /// 現在のSlimeのパラメータ
        /// </summary>
        public ReadOnlyReactiveProperty<SlimeParameters> CurrentSlimeParameter { get { return _currentSlimeParameter; } }
        
        /// <summary>
        /// プレイヤのパラメータを規定値に戻す
        /// </summary>
        public void ResetSlimeParameter()
        {
            _currentSlimeParameter.Value = DefaultSlimeParameter;
        }

        public void SetSlimeParameter(SlimeParameters parameters)
        {
            _currentSlimeParameter.Value = parameters;
        }

        private ReactiveProperty<bool> _isInitialize = new ReactiveProperty<bool>(false);
        public ReadOnlyReactiveProperty<bool> IsInitialize { get { return _isInitialize; } }
        
        /// <summary>
        /// プレイや生成後にGameManagerがこれを呼び出して初期化する
        /// </summary>
        public void InitializeSlime(SlimeParameters slimeParameters)
        {
            DefaultSlimeParameter = slimeParameters;
            _isInitialize.OnNext(true);
            _isInitialize.OnCompleted();
            
            _currentSlimeParameter = new ReactiveProperty<SlimeParameters>(DefaultSlimeParameter);
        }
    }
}