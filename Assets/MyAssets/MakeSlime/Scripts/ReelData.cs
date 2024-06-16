using UnityEngine;

namespace Assets.MyAssets.MakeSlime
{
    public class ReelData : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
            }
        }
    }
}
