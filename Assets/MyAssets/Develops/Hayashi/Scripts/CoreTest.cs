using UnityEngine;
using R3;
using Assets.MyAssets.InGame.Slimes;

public class CoreTest : MonoBehaviour
{
    [SerializeField]
    private SlimeCore _core;
    
    [SerializeField]
    private SlimeParameters _slimeParameter;
    
    void Start()
    {
        
        _core.InitializeSlime(_slimeParameter, SpecialTypes.Fire);
        
        _core.CurrentSlimeParameter.Subscribe(_ =>
        {
            Debug.Log(_core.CurrentSlimeParameter.CurrentValue.Size);
        });
    }
}
