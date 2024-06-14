using R3;

namespace Assets.MyAssets.MakeSlime.Inputs
{
    /// <summary>
    /// スライム生成画面の入力に対するイベント
    /// </summary>
    public interface IMakeSlimeInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> UpButton { get; }
        ReadOnlyReactiveProperty<bool> DownButton { get; }
        ReadOnlyReactiveProperty<bool> RightButton { get; }
        ReadOnlyReactiveProperty<bool> LeftButton { get; }
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
        ReadOnlyReactiveProperty<bool> ReturnButton { get; }
    }
}