using UnityEngine;
using R3;
using R3.Triggers;
using System;
using System.Security.Cryptography;

public class LizardMan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private ParticleSystem sliceParticleL;
    [SerializeField]
    private ParticleSystem sliceParticleR;
    [SerializeField]
    private ParticleSystem fireChargeParticle;
    [SerializeField]
    private ParticleSystem fireParticle;

    [SerializeField]
    private Collider2D sliceCollider;
    [SerializeField]
    private Collider2D fireCollider;

    private bool isDamage = false;

    const float sliceCooltime = 2f;
    const float fireCooltime = 9f;

    private float sliceCooltimeCount = 0;
    private float fireCooltimeCount = 0;

    private int condition;
    int Condition
    {
        get
        {
            return condition;
        }
        set
        {
            condition = value;
            animator.SetInteger("Condition", condition);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Condition);
        sliceCooltimeCount += Time.deltaTime;
        fireCooltimeCount += Time.deltaTime;
        if (Condition != 0) return;

        if (Mathf.Abs(player.transform.position.x - transform.position.x) > 0.05f)
        {
            if (player.transform.position.x > transform.position.x) //プレイヤーが右側にいる場合
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                fireParticle.transform.rotation = Quaternion.Euler( new Vector3(0, 0, -200));
            }
            else //プレイヤーが左側にいる場合
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                fireParticle.transform.rotation = Quaternion.Euler( new Vector3(0, 0, 20));
            }
        }

        //火炎放射
        if (fireCooltimeCount >= fireCooltime && UnityEngine.Random.Range(0, 10) == 7)
        {
            //範囲内で射線が通っているときのみ放射する
            if (Physics2D.OverlapBox((Vector2)transform.position + new Vector2(transform.localScale.x * -4.4f, -4.4f), new Vector2(8.8f, 8.8f), 0f, 1 << 6))
            {
                Vector2 vec = player.transform.position - transform.position;
                Ray2D ray = new Ray2D(transform.position, vec.normalized);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 8.8f, ~(1 << 7));

                if (hit.collider.gameObject.layer == 6)
                {
                    fireCooltimeCount = 0;
                    Condition = 3;
                    return;
                }
            }
        }

        //距離詰め
        else if (MathF.Abs(player.transform.position.x - transform.position.x) >= 6f)
        {
            Ray2D ray = new Ray2D(new Vector2(transform.position.x - transform.localScale.x * 1.2f, transform.position.y - 2f), -transform.up);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, ~(1 << 6 | 1 << 7));

            //rayを可視化
            Debug.DrawRay(ray.origin, ray.direction * 1.2f, Color.green, 0.015f);

            if (hit.collider)
            {
                Condition = 2;
                return;
            }
        }

        //斬撃
        else if (sliceCooltimeCount >= sliceCooltime && (player.transform.position - transform.position).magnitude <= 2.2f)
        {
            sliceCooltimeCount = 0;
            Condition = 1;
            return;
        }

        //歩行
        else if (Mathf.Abs(player.transform.position.x - transform.position.x) > 1f)
        {
            rb.MovePosition(new Vector2(transform.position.x - transform.localScale.x / 12f, transform.position.y - 0.01f));
        }



    }



    public void OnSlice()
    {
        if (transform.localScale.x >= 0)
        {
            sliceParticleL.Play();
        }
        else
        {
            sliceParticleR.Play();
        }
        Observable.Timer(TimeSpan.FromSeconds(0.7)).Take(1).Subscribe(_ =>
        {
            Condition = 0;
        });
    }

    public void OnFireCharge()
    {
        fireChargeParticle.Play();
    }

    public void OnFire()
    {
        
        fireParticle.Play();
        Observable.Timer(TimeSpan.FromSeconds(1.45f)).Take(1).Subscribe(_ =>
        {
            Condition = 0;
        });

    }

    private bool isOver0;
    private bool isOver1;

    public void OnJump()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 target = playerPos + new Vector3(transform.localScale.x * 1, 1, 0);
        Vector3 vec = target - transform.position;
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y + 1f));
        isOver0 = transform.position.x >= target.x;
        isOver1 = transform.position.x >= target.x;
        this.UpdateAsObservable().Take(1).Subscribe(_ =>
        {
            Vector2 force = vec.normalized * Mathf.Sqrt(144 * Mathf.Sqrt(Mathf.Abs(vec.x)));
            if (force.y <= 10)
            {
                force.y = 10;
            }
            rb.AddForce(force, ForceMode2D.Impulse);
        });
        this.UpdateAsObservable().Take(60).Subscribe(_ =>
        {
            isOver1 = transform.position.x >= target.x;
            if (isOver0 != isOver1) rb.velocity = Vector2.zero;
            isOver0 = transform.position.x >= target.x;
        });
        Observable.Timer(TimeSpan.FromSeconds(1)).Take(1).Subscribe(_ =>
        {
            Debug.Log("Reset");
            Condition = 0;
        });

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag != "Player") return;
        if (fireCollider.enabled)
        {
            fireCollider.enabled = false;
            {

            }
        }
        if (sliceCollider.enabled)
        {
            sliceCollider.enabled = false;
            if (isDamage)
            {
                //ダメージ処理
            }
        }
    }
}
