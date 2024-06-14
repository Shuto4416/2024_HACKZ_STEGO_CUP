using R3;

namespace Assets.MyAssets.GameOver.Inputs
{
    /// <summary>
    /// ゲームオーバー画面の入力に対するイベント
    /// </summary>
    public interface IGameOverInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
    }
}