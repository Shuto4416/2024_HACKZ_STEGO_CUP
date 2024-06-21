using Assets.MyAssets.InGame.Slimes;
using UnityEngine;

public class NoCollisionWithPlayer : MonoBehaviour
{


    void Start()
    {
        foreach (var objectCollider in this.GetComponentsInChildren<Collider2D>())
        {
            foreach (var slimeCollider in SlimeCore.Colliders)
            {
                Physics2D.IgnoreCollision(objectCollider, slimeCollider);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
