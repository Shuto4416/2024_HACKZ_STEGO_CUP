using R3;

namespace Assets.MyAssets.InGame.Slimes.Inputs
{
    /// <summary>
    /// インゲームの入力に対するイベント
    /// </summary>
    public interface IInGameInputEventProvider
    {
        ReadOnlyReactiveProperty<float> XMoveDirection { get; }
        ReadOnlyReactiveProperty<bool> OnSpecialButtonPushed { get; }
        ReadOnlyReactiveProperty<bool> OnJumpButtonPushed { get; }
        ReadOnlyReactiveProperty<bool> PauseButton { get; }
    }
}