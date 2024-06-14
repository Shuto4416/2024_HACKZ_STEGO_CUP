using R3;

namespace Assets.MyAssets.Title.Inputs
{
    /// <summary>
    /// タイトルの入力に対するイベント
    /// </summary>
    public interface ITitleInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> UpButton { get; }
        ReadOnlyReactiveProperty<bool> DownButton { get; }
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
    }
}