using UnityEngine;
using R3;
using System;

public class EnemyCore : MonoBehaviour
{
    public ReadOnlyReactiveProperty<EnemyParameters> CurrentEnemyParameter { get { return currentEnemyParameter; } }
    [SerializeField] private int hitPoint;
    private ReactiveProperty<EnemyParameters> currentEnemyParameter;

    [SerializeField] private GameObject rootObject;



    public void ApplyDamage(int damage)
    {
        currentEnemyParameter.Value.HitPoint -= damage;
        if (currentEnemyParameter.Value.HitPoint <= 0)
        {
            Destroy(rootObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentEnemyParameter = new ReactiveProperty<EnemyParameters>(new EnemyParameters(hitPoint));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.ApplyDamage(10);
            Debug.Log(gameObject.name + currentEnemyParameter.Value.HitPoint);
        }
    }
}

public class EnemyParameters
{
    public int HitPoint;
    public float MoveSpeed;

    public EnemyParameters(int hitPoint, float moveSpeed = 1f)
    {
        HitPoint = hitPoint;
        MoveSpeed = moveSpeed;
    }
}