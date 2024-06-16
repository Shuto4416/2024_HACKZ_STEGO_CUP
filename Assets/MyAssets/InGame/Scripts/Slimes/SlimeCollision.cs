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

        [SerializeField]
        private SlimeCore _slimeCore;
        
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                _isGround = true;
            }
            if (collision.gameObject.tag == "Gem")
            {
                _slimeCore.ClearGame();
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