using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuto_Stickey : MonoBehaviour
{
    [SerializeField]
    SpringJoint2D spring;
    LineRenderer lineRenderer;

    bool isSticking = false;

    Vector3[] lerps;

    [SerializeField, Range(0, 1)]
    float viscosity = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 5;
        lineRenderer.widthMultiplier = UnityEngine.Random.Range(0.15f,0.65f);
        lerps = new Vector3[5];
        Init();
    }

    void Init()
    {
        spring.breakForce = 200 * viscosity;
        spring.frequency = 100 / (viscosity * 100 + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSticking)
        {
            lineRenderer.enabled = true;
            lerps = new Vector3[5];
            Vector3 pos = transform.position;
            Vector3 connectedPos = spring.connectedBody.transform.TransformPoint(spring.connectedAnchor);
            for (int i = 0; i < 5; i++)
            {
                lerps[i] = Vector3.LerpUnclamped(pos, connectedPos, i * 0.28f);
            }
            lineRenderer.SetPositions(lerps);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SlimeController" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") return;
        spring.connectedBody = collision.rigidbody;
        spring.enabled = true;
        spring.connectedAnchor = collision.gameObject.transform.InverseTransformPoint(collision.GetContact(0).point);
        isSticking = true;
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        if (joint == spring)
        {
            isSticking = false;
            spring.enabled = false;
        }
    }
}
