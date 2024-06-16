using System.Collections;
using Assets.MyAssets.InGame.Slimes;
using Assets.MyAssets.Common.Scripts.Scenes;
using R3;
using UnityEngine;

namespace Assets.MyAssets.InGame.GameManagers
{
    public class MainGameManager : MonoBehaviour
    {
        private GameStateReactiveProperty _currentState = new GameStateReactiveProperty(GameState.Initialization);

        public ReadOnlyReactiveProperty<GameState> CurrentGameState => _currentState;

        private TimeManager _timeManager;
        
        [SerializeField]
        private SlimeCore _core;
        
        private Common.Scripts.Scenes.InGame _inGame;
        
        void Start()
        {
            _inGame = GetComponent<Common.Scripts.Scenes.InGame>();
            _timeManager = GetComponent<TimeManager>();
            
            _currentState.Subscribe(state =>
            {
                OnStateChanged(state);
            });
        }
        
        void OnStateChanged(GameState nextState)
        {
            switch (nextState)
            {
                case GameState.Initialization:
                    //StartCoroutine(InitCoroutine());
                    break;
                case GameState.Ready:
                    //Ready();
                    break;
                case GameState.Game:
                    //MainGame();
                    break;
                case GameState.Finish:
                    //Finish();
                    break;
                default:
                    break;
            }
        }
        
        IEnumerator InitCoroutine()
        {
            _core.InitializeSlime(new SlimeParameters(3,_inGame.Weight,_inGame.Size,_inGame.Viscosity), _inGame.SpecialTypes);
            
            yield return null;
            
            _currentState.Value = GameState.Ready;
        }


    }
}