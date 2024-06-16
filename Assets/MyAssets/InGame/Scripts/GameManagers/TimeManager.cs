using System.Collections;
using UnityEngine;
using R3;

namespace Assets.MyAssets.InGame.GameManagers
{
    /// <summary>
    /// 時間を管理するクラス
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private ReactiveProperty<int> _gameCountDownSecond = new ReactiveProperty<int>(300);

        /// <summary>
        /// ゲームのカウントダウン
        /// </summary>
        public ReadOnlyReactiveProperty<int> GameCountDownSecond => _gameCountDownSecond;

        private bool _playGame;

        private void Awake()
        {
            _playGame = true;
        }

        /// <summary>
        /// タイムカウントを開始するメソッド
        /// </summary>
        public void StartGameCountDown()
        {
            StartCoroutine(GameCountUpCoroutine());
        }

        /// <summary>
        /// タイムカウントを行うコルーチン
        /// </summary>
        IEnumerator GameCountUpCoroutine()
        {
            while (_playGame)
            {
                yield return new WaitForSeconds(1);
                _gameCountDownSecond.Value--;
            }
        }

        //カウントダウンを停止させるメソッド
        public void StopCountDown()
        {
            if (_playGame)
            {
                _playGame = false;
            }
        }
    }
}