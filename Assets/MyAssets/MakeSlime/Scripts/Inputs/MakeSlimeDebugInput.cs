using System;
using R3;
using R3.Triggers;
using UnityEngine;

public class MakeSlimeDebugInput : MonoBehaviour
{
    private ReactiveProperty<bool> _upButton;
    private ReactiveProperty<bool> _downButton;
    private ReactiveProperty<bool> _rightButton;
    private ReactiveProperty<bool> _leftButton;
    private ReactiveProperty<bool> _decideButton;
    private ReactiveProperty<bool> _returnButton;
    
    ReadOnlyReactiveProperty<bool> UpButton
    {
        get { return _upButton; }
    }
    ReadOnlyReactiveProperty<bool> DownButton     
    {
        get { return _downButton; }
    }
    ReadOnlyReactiveProperty<bool> RightButton     
    {
        get { return _rightButton; }
    }
    ReadOnlyReactiveProperty<bool> LeftButton   
    {
        get { return _leftButton; }
    }
    ReadOnlyReactiveProperty<bool> DecideButton     
    {
        get { return _decideButton; }
    }
    ReadOnlyReactiveProperty<bool> ReturnButton    
    {
        get { return _returnButton; }
    }
    
    void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.W))
            .DistinctUntilChanged()
            .Subscribe(x => _upButton.Value = x);
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.S))
            .DistinctUntilChanged()
            .Subscribe(x => _downButton.Value = x);
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.D))
            .DistinctUntilChanged()
            .Subscribe(x => _rightButton.Value = x);
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.A))
            .DistinctUntilChanged()
            .Subscribe(x => _leftButton.Value = x);           
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.Space))
            .DistinctUntilChanged()
            .Subscribe(x => _decideButton.Value = x);   
        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.Escape))
            .DistinctUntilChanged()
            .Subscribe(x => _returnButton.Value = x); 
    }
}
