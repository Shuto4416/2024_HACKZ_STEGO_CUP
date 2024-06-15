using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// スライムの動きの定義
    /// </summary>
    public class SlimeMover : BaseSlimeComponent
    {
        private ReactiveProperty<bool> _isGrounded = new ReactiveProperty<bool>(true);

        public ReadOnlyReactiveProperty<bool> IsGrounded { get { return _isGrounded; } }

        private int _inputDirection;
        
        List<Rigidbody2D> rigidbody2Ds;

        protected override void OnInitialize()
        {
            rigidbody2Ds = gameObject.GetComponentsInChildrenWithoutSelf<Rigidbody2D>().ToList();
        }

        /// <summary>
        /// Move the specified velocity.
        /// </summary>
        /// <param name="velocity">Velocity.</param>
        public void Move(Vector2 destination, float multiplier, int count = 12, ForceMode2D forceMode = ForceMode2D.Force)
        {
            switch (forceMode)
            {
                case ForceMode2D.Force:
                    rigidbody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count).ToList().ForEach(x => x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                    break;
                case ForceMode2D.Impulse:
                    rigidbody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count).ToList().ForEach(x => x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                    break;
                default:
                    break;
            }
        }
    }
}
