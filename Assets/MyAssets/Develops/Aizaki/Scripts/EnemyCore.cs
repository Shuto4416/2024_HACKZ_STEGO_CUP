using UnityEngine;
using R3;
using System;

public class EnemyCore : MonoBehaviour
{
    //public ReadOnlyReactiveProperty<EnemyParameters> CurrentEnemyParameter { get { return currentEnemyParameter; } }
    [SerializeField] private int hitPoint;
    private EnemyParameters currentEnemyParameter;



    public void ApplyDamage(int damage)
    {
        currentEnemyParameter.HitPoint -= damage;
        if (currentEnemyParameter.HitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnemyParameter = new EnemyParameters(hitPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
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
