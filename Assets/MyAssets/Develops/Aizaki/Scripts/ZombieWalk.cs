using Unity.VisualScripting;
using UnityEngine;

public class ZombieWalk : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(new Vector2(transform.position.x - transform.localScale.x / 30f, transform.position.y - 0.05f));

        
        Ray2D ray = new Ray2D(new Vector2(transform.position.x - transform.localScale.x * 0.5f, transform.position.y - 1.65f), -transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, ~(1 << 6 | 1 << 7));
        if (!hit.collider)
        {
            ray = new Ray2D(new Vector2(transform.position.x, transform.position.y - 1.65f), -transform.up);
            hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, ~(1 << 6 | 1 << 7));
            if (hit.collider)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }

        ray = new Ray2D(new Vector2(transform.position.x - transform.localScale.x * 0.5f, transform.position.y + 0.5f), -transform.up);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 2f, ~(1 << 6 | 1 << 7));
        if (hit.collider)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
