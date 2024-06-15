using Assets.MyAssets.InGame.Slimes.Inputs;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes.Specials
{
    /// <summary>
    /// スペシャルの基底クラス
    /// </summary>
    public abstract class BaseSpecial : MonoBehaviour
    {
        public abstract void OnInitialize(IInGameInputEventProvider inGameInputEventProvider);
    }
}
