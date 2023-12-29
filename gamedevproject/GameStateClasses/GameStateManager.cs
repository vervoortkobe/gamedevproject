using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.GameStateClasses
{
    internal class GameStateManager
    {
        private GameState gameState { get; set; }

        public GameStateManager()
        {
            return;
        }

        public GameStateManager(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void ExecuteGameState(GameStates gameState)
        {
            switch (gameState)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    break;
                case GameStates.LEVEL2:
                    break;
                case GameStates.LEVEL3:
                    break;
                case GameStates.VICTORY:
                    break;
                case GameStates.GAMEOVER:
                    break;
                default:
                    break;
            }
        }
    }
}
