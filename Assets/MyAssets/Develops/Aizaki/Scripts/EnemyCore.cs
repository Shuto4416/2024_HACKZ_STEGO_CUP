using UnityEngine;
using R3;
using System;

public class EnemyCore : MonoBehaviour
{
    //public ReadOnlyReactiveProperty<EnemyParameters> CurrentEnemyParameter { get { return currentEnemyParameter; } }

    //EnemyParameters currentEnemyParameter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class EnemyParameters
{
    int HitPoint;
    float MoveSpeed;

    public EnemyParameters(int hitPoint, float moveSpeed = 1f)
    {
        HitPoint = hitPoint;
        MoveSpeed = moveSpeed;
    }
}
