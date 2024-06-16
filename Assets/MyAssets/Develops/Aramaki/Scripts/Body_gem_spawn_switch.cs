using UnityEngine;

public class Body_gem_spawn_switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Body_gem;
    void Start()
    {
        Body_gem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("pusher")) Body_gem.SetActive(true);
    }
}
