using System;
using UnityEngine;
using R3;

namespace Assets.MyAssets.InGame.Slimes.Specials
{
    /// <summary>
    /// 風属性のスペシャルのクラス
    /// </summary>
    public class SpecialWind : BaseSpecial
    {
        private SpecialTypes _specialTypes = SpecialTypes.Wind;
        [SerializeField]
        private Rigidbody2D _rigidBody2D;

        private float _forcePower = 15f;
        
        public override void OnInitialize(float xDirection)
        {
            _rigidBody2D.AddForce(new Vector2(xDirection,0F) * _forcePower,ForceMode2D.Impulse);
            
            Observable.Timer(TimeSpan.FromSeconds(1.5f))
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