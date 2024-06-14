using UnityEngine;
using R3;
using Assets.MyAssets.InGame.Slimes;

public class CoreTest : MonoBehaviour
{
    [SerializeField]
    private SlimeCore _core;
    
    [SerializeField]
    private SlimeParameters SlimeParameter;
    
    void Start()
    {
        _core.InitializeSlime(SlimeParameter);

        _core.CurrentSlimeParameter.Subscribe(_ =>
        {
            Debug.Log(_core.CurrentSlimeParameter.CurrentValue.Size);
        });

        _core.IsDamaged
            .Skip(1).Subscribe(_ => Debug.Log("痛い"));
        _core.IsDead
            .Skip(1).Subscribe(_ => Debug.Log("死んだ"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _core.ApplyDamage();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _core.Kill();
        }
    }
}
