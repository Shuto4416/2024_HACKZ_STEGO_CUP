using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeの移動管理クラス
    /// </summary>
    public class SlimeMoving : BaseSlimeComponent
    {
        List<Rigidbody2D> _rigidBody2Ds;
        List<Transform> _transforms;
        private List<SlimeSticky> _slimeStickies;

        [SerializeField]
        private SlimeCollision _slimeCollision;

        [SerializeField] GameObject _eye;

        protected override void OnInitialize()
        {
            _rigidBody2Ds = gameObject.GetComponentsInChildrenWithoutSelf<Rigidbody2D>().ToList();
            _transforms = gameObject.GetComponentsInChildrenWithoutSelf<Transform>().ToList();
            _slimeStickies = gameObject.GetComponentsInChildrenWithoutSelf<SlimeSticky>().ToList();
        }

        Vector2 _cursorWorldPos;
        Vector3 _eyePos;

        void Update()
        {
            var multiplier = SlimeCore.DefaultMultiplier;
            if (!_slimeCollision.IsGround)
            {
                multiplier = SlimeCore.DefaultMultiplier / 2;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                Move((Vector2)transform.position + new Vector2(-5, 0), multiplier, 12);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move((Vector2)transform.position + new Vector2(5, 0), multiplier, 12);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move((Vector2)transform.position + new Vector2(0, -5), multiplier, 12);
            }
            
            if (Input.GetKeyDown(KeyCode.W) && _slimeCollision.IsGround)
            {
                Move((Vector2)transform.position + new Vector2(0, 5), 10, 10, ForceMode2D.Impulse);
            }
            
            /*
            eyePos.x = transforms.Average(x => x.position.x);
            eyePos.y = transforms.Average(x => x.position.y);
            eye.transform.position = eyePos;
            */
        }

        void Move(Vector2 destination, float multiplier, int count, ForceMode2D forceMode = ForceMode2D.Force)
        {
            switch (forceMode)
            {
                case ForceMode2D.Force:
                    _rigidBody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count)
                        .ToList().ForEach(x =>
                            x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                    break;
                case ForceMode2D.Impulse:
                    _rigidBody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count)
                        .ToList().ForEach(x =>
                            x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                    break;
                default:
                    break;
            }
        }
    }
}
