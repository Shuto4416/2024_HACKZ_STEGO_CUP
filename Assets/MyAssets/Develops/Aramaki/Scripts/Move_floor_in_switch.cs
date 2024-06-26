using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Move_floor_in_switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D MoveFloor_RigidBody;
    Transform Startposition;
    [SerializeField] private float _x; //_x = -36
    [SerializeField] private float _y;
    [SerializeField] private float _duration;
    [SerializeField] private Switch _switch;
    bool is_first = true;
    void Start()
    {
        Startposition = GetComponent<Transform>();
        MoveFloor_RigidBody = GetComponent<Rigidbody2D>();
        //MoveFloor_RigidBody.DOMove(new Vector2(Startposition.position.x + _x, Startposition.position.y + _y),_duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("SlimeController") && is_first) {
            if(_switch.is_push) {
                MoveFloor_RigidBody.DOMove(new Vector2(Startposition.position.x + _x, Startposition.position.y + _y),_duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
                is_first = false;
            }
        }
    }
}
