using System;
using R3;

namespace Assets.MyAssets.InGame.GameManagers
{
    public enum GameState
    {
        Initialization,
        Ready,
        Game,
        Finish
    }
    
    [Serializable]
    public class GameStateReactiveProperty : ReactiveProperty<GameState>
    {
        public GameStateReactiveProperty()
        {
        }

        public GameStateReactiveProperty(GameState initialValue)
            : base(initialValue)
        {
        }
    }
}