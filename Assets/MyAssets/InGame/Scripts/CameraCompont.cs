using UnityEngine;

public class CameraCompont : MonoBehaviour
{    
    [SerializeField]
    GameObject _slime;
    
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //横方向だけ追従
        transform.position = new Vector3(_slime.transform.position.x, _slime.transform.position.y, transform.position.z);
    }
}
