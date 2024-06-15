using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    List<Rigidbody2D> rigidbody2Ds;
    List<Transform> transforms;

    [SerializeField] GameObject eye;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2Ds = gameObject.GetComponentsInChildrenWithoutSelf<Rigidbody2D>().ToList();
        transforms = gameObject.GetComponentsInChildrenWithoutSelf<Transform>().ToList();
    }

    float time;
    Vector2 cursorWorldPos;
    Vector3 eyePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursorWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Move(cursorWorldPos, 20f, 10, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Move((Vector2)transform.position + new Vector2(0, 10), 20f, 10, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move((Vector2)transform.position + new Vector2(-5, 0), 15f, 12);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move((Vector2)transform.position + new Vector2(0, -5), 30f, 12);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move((Vector2)transform.position + new Vector2(5, 0), 15f, 12);
        }

        eyePos.x = transforms.Average(x => x.position.x);
        eyePos.y = transforms.Average(x => x.position.y);
        eye.transform.position = eyePos;
    }

    void Move(Vector2 destination, float multiplier)
    {
        Move(destination, multiplier, 3, ForceMode2D.Force);
    }

    void Move(Vector2 destination, float multiplier, int count)
    {
        Move(destination, multiplier, count, ForceMode2D.Force);
    }

    void Move(Vector2 destination, float multiplier, int count, ForceMode2D forceMode)
    {
        switch (forceMode)
        {
            case ForceMode2D.Force:
                rigidbody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count).ToList().ForEach(x => x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                break;
            case ForceMode2D.Impulse:
                rigidbody2Ds.OrderBy(x => (destination - (Vector2)x.transform.position).sqrMagnitude).Take(count).ToList().ForEach(x => x.AddForce((destination - (Vector2)transform.position).normalized * multiplier, forceMode));
                break;
            default:
                break;
        }
        

    }
}

public static class GameObjectExtensions
{
    public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self, bool includeInactive = false) where T : Component
    {
        return self
            .GetComponentsInChildren<T>(includeInactive)
            .Where(c => self != c.gameObject)
            .ToArray();
    }
}