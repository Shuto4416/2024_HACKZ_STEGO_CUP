using UnityEngine;
using DG.Tweening;

public class Move_floor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D MoveFloor;
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _duration;
    void Start()
    {
        Transform Startposition = GetComponent<Transform>();
        MoveFloor = GetComponent<Rigidbody2D>();
        MoveFloor.DOMove(new Vector2(Startposition.position.x + _x, Startposition.position.y + _y),_duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
