using System;
using UnityEngine;
using R3;
using Assets.MyAssets.InGame.Slimes.Interfaces;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeのメイン実装
    /// </summary>
    public class SlimeCore : MonoBehaviour, IDamageable, IDieable
    {
        private ReactiveProperty<bool> _isDamaged = new ReactiveProperty<bool>(false);
        public ReadOnlyReactiveProperty<bool> IsDamaged { get { return _isDamaged; } }
        
        private ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>(false);
        public ReadOnlyReactiveProperty<bool> IsDead { get { return _isDead; } }
        
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
        /// Slimeのパラメータを規定値に戻す
        /// </summary>
        public void ResetSlimeParameter()
        {
            _currentSlimeParameter.Value = DefaultSlimeParameter;
        }

        /// <summary>
        /// Slimeのパラメータを変更する
        /// </summary>
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

            _isDamaged
                .Where(_ => _isDamaged.Value)
                .Subscribe(_ =>
                {
                    if (_currentSlimeParameter.Value.HitPoint <= 0)
                    {
                        _isDead.Value = true;
                        return;
                    }
                    //1秒後に元の状態に
                    Observable.Timer(TimeSpan.FromSeconds(1))
                        .Subscribe(_ => _isDamaged.Value = false);
                });
        }
        
        /// <summary>
        /// Slimeにダメージを与える
        /// </summary>
        public void ApplyDamage()
        {
            if (_isDamaged.Value || _isDead.Value)
            {
                return;
            }
            
            _currentSlimeParameter.Value.HitPoint--;
            
            _isDamaged.Value = true;
        }

        /// <summary>
        /// Slimeを即死させる
        /// </summary>
        public void Kill()
        {
            _isDead.Value = true;
        }
    }
}