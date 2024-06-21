using UnityEngine;
using R3;
using UnityEditor;

public class StatusPresenter : MonoBehaviour
{
    public StatusModel _model;
    public HpBarView _healthView;
    void Awake() {
        _model._hp.Subscribe(value => { 
            if (value > _model._healthMax) _model.Health = _model._healthMax;
            if (value < 0) _model.Health = 0;
            _healthView.SetRate(_model._healthMax, value);});
    }
}
