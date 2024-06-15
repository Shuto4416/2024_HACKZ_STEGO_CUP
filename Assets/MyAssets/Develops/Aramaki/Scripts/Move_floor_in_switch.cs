using UnityEngine;
using DG.Tweening;

public class Move_floor_in_switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D MoveFloor;
    Transform Startposition;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float time;
    Switch @switch;
    void Start()
    {
        Startposition = GetComponent<Transform>();
        MoveFloor = GetComponent<Rigidbody2D>();
        //MoveFloor.DOMove(new Vector2(Startposition.position.x + x, Startposition.position.y + y),time).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(@switch == true) {
            MoveFloor.DOMove(new Vector2(Startposition.position.x + x, Startposition.position.y + y),time).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo).Play();
        } else {
            MoveFloor.DOMove(new Vector2(Startposition.position.x + x, Startposition.position.y + y),time).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo).Pause();
        }
    }
}
