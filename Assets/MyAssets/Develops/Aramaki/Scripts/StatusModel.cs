using UnityEngine;

using R3;

public class StatusModel : MonoBehaviour
{
    public int _healthMax;
    public SerializableReactiveProperty<int> _hp = new SerializableReactiveProperty<int>();

    public int Health
    {
        get { return _hp.Value; }
        set { _hp.Value = value; }
    }
    
}
