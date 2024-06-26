using UnityEngine;

public class Body_gem_spawn_switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject _bodyGem;
    void Start()
    {
        _bodyGem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("pusher")) _bodyGem.SetActive(true);
    }
}
