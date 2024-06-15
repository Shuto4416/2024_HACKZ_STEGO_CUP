using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeの当たり判定
    /// </summary>
    public class SlimeCollision : MonoBehaviour
    {
        private bool _isGround;
        public bool IsGround { get {return _isGround;} }
        
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                _isGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                _isGround = false;
            }
        }
    }
}