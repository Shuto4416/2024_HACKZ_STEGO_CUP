using UnityEngine;
using R3;
using Assets.MyAssets.InGame.Slimes;

public class CoreTest : MonoBehaviour
{
    [SerializeField]
    private SlimeCore _core;
    
    [SerializeField]
    private SlimeParameters _slimeParameter;

    [SerializeField]
    private SpecialTypes _specialTypes;
    
    void Start()
    {
        _core.InitializeSlime(_slimeParameter, _specialTypes);
        
        _core.CurrentSlimeParameter.Subscribe(_ =>
        {
            Debug.Log(_core.CurrentSlimeParameter.CurrentValue.Size);
        });
    }
}
