using UnityEngine;

namespace Assets.MyAssets.InGame.Cameras
{
    /// <summary>
    /// カメラ処理に関するクラス
    /// </summary>
    public class CameraComponent : MonoBehaviour
    {    
        [SerializeField]
        Transform _slimeTransform;
    
        void LateUpdate()
        {
            MoveCamera();
        }
        
        /// <summary>
        /// カメラの移動
        /// </summary>
        void MoveCamera()
        {
            //横方向だけ追従
            transform.position = new Vector3(_slimeTransform.position.x, _slimeTransform.position.y, transform.position.z);
        }
    }

}
