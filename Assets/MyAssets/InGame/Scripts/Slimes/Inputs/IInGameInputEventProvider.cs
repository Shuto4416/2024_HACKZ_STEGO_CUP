using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes.Inputs
{
    /// <summary>
    /// インゲームの入力に対するイベント
    /// </summary>
    public interface IInGameInputEventProvider
    {
        ReadOnlyReactiveProperty<Vector2> MoveDirection { get; }
        ReadOnlyReactiveProperty<bool> OnSpecialButtonPushed { get; }
        ReadOnlyReactiveProperty<bool> PauseButton { get; }
    }
}