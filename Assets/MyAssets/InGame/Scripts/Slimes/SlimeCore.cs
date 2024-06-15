using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private SpecialTypes _specialTypes;
        public SpecialTypes SpecialTypes { get { return _specialTypes; } }
        
        List<Rigidbody2D> _rigidBody2Ds;
        
        private float _defaultMultiplier = 5;
        public float DefaultMultiplier { get { return _defaultMultiplier; } }

        private float _viscosity = 0f;
        public float Viscosity { get { return _viscosity; } }
        
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
        public void InitializeSlime(SlimeParameters slimeParameters, SpecialTypes specialTypes)
        {
            _rigidBody2Ds = gameObject.GetComponentsInChildrenWithoutSelf<Rigidbody2D>().ToList();
            
            DefaultSlimeParameter = slimeParameters;
            _specialTypes = specialTypes;
            _isInitialize.OnNext(true);
            _isInitialize.OnCompleted();
            
            _currentSlimeParameter = new ReactiveProperty<SlimeParameters>(DefaultSlimeParameter);

            this.gameObject.transform.localScale *= DefaultSlimeParameter.Size;

            _defaultMultiplier /= DefaultSlimeParameter.Weight + 0.5f;
            
            foreach (var _rigidBody2D in _rigidBody2Ds)
            {
                _rigidBody2D.mass = DefaultSlimeParameter.Weight;
            }

            this.gameObject.GetComponent<SpriteRenderer>().material.color = SpecialTypes.ToColor();

            foreach (var spriteRenderer in this.gameObject.GetComponentsInChildrenWithoutSelf<Renderer>().ToList())
            {
                spriteRenderer.material.color = SpecialTypes.ToColor();
            }
            

            _viscosity = DefaultSlimeParameter.Viscosity;
            
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