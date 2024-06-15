using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Move_floor_in_switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D MoveFloor;
    Transform Startposition;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float time;
    public Switch @switch;
    bool once = true;
    void Start()
    {
        Startposition = GetComponent<Transform>();
        MoveFloor = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("SlimeController") && once == true) {
            if(@switch.button == true) {
                MoveFloor.DOMove(new Vector2(Startposition.position.x + x, Startposition.position.y + y),time).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
                once = false;
            }
        }
    }
}
