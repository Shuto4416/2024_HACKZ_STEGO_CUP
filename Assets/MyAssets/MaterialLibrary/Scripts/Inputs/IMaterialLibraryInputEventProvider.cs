using R3;

namespace Assets.MyAssets.MaterialLibrary.Inputs
{
    /// <summary>
    /// 素材図鑑画面の入力に対するイベント
    /// </summary>
    public interface IMaterialLibraryInputEventProvider
    {
        ReadOnlyReactiveProperty<bool> UpButton { get; }
        ReadOnlyReactiveProperty<bool> DownButton { get; }
        ReadOnlyReactiveProperty<bool> RightButton { get; }
        ReadOnlyReactiveProperty<bool> LeftButton { get; }
        ReadOnlyReactiveProperty<bool> DecideButton { get; }
        ReadOnlyReactiveProperty<bool> ReturnButton { get; }
    }
}