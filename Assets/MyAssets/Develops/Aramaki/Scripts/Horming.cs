using UnityEngine;

public class Horming : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform gameobject;
    Transform transForm;
    void Start()
    {
        transForm = GetComponent<Transform>();
        this.GetComponent<Camera>().orthographicSize = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transForm.position = new Vector3(gameobject.transform.position.x, gameobject.transform.position.y, transForm.position.z);
    }
}
