using Assets.MyAssets.InGame.Slimes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField]
    private List<Collider2D> DamageAreas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        Debug.Log("Hit");
        collision.gameObject.GetComponent<SlimeCore>().ApplyDamage();
        DamageAreas.ForEach(x => x.gameObject.SetActive(false));
    }
}
