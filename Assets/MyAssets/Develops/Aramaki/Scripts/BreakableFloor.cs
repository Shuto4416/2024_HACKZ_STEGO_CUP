using Assets.MyAssets.Common.Scripts.Scenes;
using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InGame _playerData;
    [SerializeField] float _durableValue;
    float _weight;
    void Start()
    {
        _weight = _playerData.Weight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SlimeController")) {
            _durableValue += other.relativeVelocity.y * _weight;
            if(_durableValue <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
