using R3;
using UnityEngine;
using Assets.MyAssets.InGame.Slimes.Inputs;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// SlimeのComponentの基底クラス
    /// </summary>
    public abstract class BaseSlimeComponent : MonoBehaviour
    {
        private IInGameInputEventProvider _inGameInputEventProvider;
        
        /// <summary>
        /// 入力のイベント通知
        /// </summary>
        protected IInGameInputEventProvider InGameInputEventProvider { get { return _inGameInputEventProvider; } }
        
        /// <summary>
        /// Slimeの基本的な情報
        /// </summary>
        protected SlimeCore SlimeCore;
        
        /// <summary>
        /// 現在のSlimeのパラメータ
        /// </summary>
        protected ReadOnlyReactiveProperty<SlimeParameters> CurrentPlayerParameter
        {
            get
            {
                return SlimeCore.CurrentSlimeParameter;
            }
        }
        
        private void Start()
        {
            SlimeCore = GetComponent<SlimeCore>();
            _inGameInputEventProvider = GetComponent<IInGameInputEventProvider>();

            //Coreの情報が確定したら初期化を呼び出す
            SlimeCore.IsInitialize
                .Subscribe(_ => OnInitialize());

            OnStart();
        }

        /// <summary>
        /// Start() と同じタイミング
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// プレイヤ情報の初期化が完了した時に実行される初期化処理
        /// </summary>
        protected abstract void OnInitialize();
    }
}
