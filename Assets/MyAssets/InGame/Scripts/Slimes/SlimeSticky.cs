using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// Slimeの粘着度を管理するスクリプト
    /// </summary>
    public class SlimeSticky : MonoBehaviour
    {
        [SerializeField] SpringJoint2D _spring;
        LineRenderer _lineRenderer;

        private bool _isSticking = false;

        Vector3[] _lerps;

        [SerializeField, Range(0, 1)] float _viscosity = 0.5f;
        
        void Start()
        {
            _lineRenderer = gameObject.GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 5;
            _lineRenderer.widthMultiplier = UnityEngine.Random.Range(0.15f, 0.65f);
            _lerps = new Vector3[5];
            Init();
        }

        void Init()
        {
            _spring.breakForce = 200 * _viscosity;
            _spring.frequency = 100 / (_viscosity * 100 + 1);
        }

        // Update is called once per frame
        void Update()
        {
            if (_isSticking)
            {
                _lineRenderer.enabled = true;
                _lerps = new Vector3[5];
                Vector3 pos = transform.position;
                Vector3 connectedPos = _spring.connectedBody.transform.TransformPoint(_spring.connectedAnchor);
                for (int i = 0; i < 5; i++)
                {
                    _lerps[i] = Vector3.LerpUnclamped(pos, connectedPos, i * 0.28f);
                }

                _lineRenderer.SetPositions(_lerps);
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "SlimeController") return;
            _spring.connectedBody = collision.rigidbody;
            _spring.enabled = true;
            _spring.connectedAnchor =
                collision.gameObject.transform.InverseTransformPoint(collision.GetContact(0).point);
            _isSticking = true;
        }

        private void OnJointBreak2D(Joint2D joint)
        {
            if (joint == _spring)
            {
                _isSticking = false;
                _spring.enabled = false;
            }
        }
    }
}
