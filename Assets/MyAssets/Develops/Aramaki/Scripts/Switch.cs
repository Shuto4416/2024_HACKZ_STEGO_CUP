using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool button = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("pusher")) button = true;
    }
}
