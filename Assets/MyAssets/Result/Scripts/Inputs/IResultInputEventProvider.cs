using R3;

namespace Assets.MyAssets.Result.Inputs
{
    /// <summary>
    /// リザルト画面の入力に対するイベント
    /// </summary>
    public interface IResultInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
    }
}