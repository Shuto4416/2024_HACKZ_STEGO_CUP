using Assets.MyAssets.InGame.Slimes.Inputs;
using UnityEngine;

namespace Assets.MyAssets.InGame.Slimes
{
    public class BaseSlimeComponent : MonoBehaviour
    {
        private IInGameInputEventProvider _inGameInputEventProvider;


        protected IInGameInputEventProvider InGameInputEventProvider { get { return _inGameInputEventProvider; } }
    }
}
