using System;
using UnityEngine;
using R3;
using DG.Tweening;

namespace Assets.MyAssets.InGame.Slimes.Specials
{
    /// <summary>
    /// 雷属性のスペシャルのクラス
    /// </summary>
    public class SpecialThunder : BaseSpecial
    {
        private SpecialTypes _specialTypes = SpecialTypes.Thunder;
        [SerializeField]
        private Rigidbody2D _rigidBody2D;

        private float _fadeSeconds = 5f;
        
        public override void OnInitialize(float xDirection)
        {
            this.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _fadeSeconds);
            
            Observable.Timer(TimeSpan.FromSeconds(_fadeSeconds))
                .Subscribe(_ => Destroy(this.gameObject)).AddTo(this);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            /*
            var ememyDamegeable = collision.gameObject.GetComponent<IEnemyDamegeable>();
            if (ememyDamegeable)
            {
                Debug.Log(ememyDamegeable);
            }*/
        }
    }
    
}