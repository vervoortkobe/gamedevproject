using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace gamedevproject.GameStateClasses
{
    public enum GameStates
    {
        STARTSCREEN, LEVEL1, LEVEL2, LEVEL3, VICTORY, GAMEOVER
    }

    public class GameStateManager
    {
        private Level _level;
        private GameState _gameState;

        public GameStateManager(IServiceProvider Services)
        {
            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 1)))
                _level = new Level(Services, fileStream, 1);
            _gameState = new GameState();
        }

        public void ExecuteGameState(GameState gameState)
        {
            switch (gameState.GameStateValue)
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

        public void Update(GameTime gameTime, GameState gameState)
        {
            switch (gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    _level.Update(gameTime);
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

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch, GameState gameState)
        {
            switch (gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    _level.Draw(gameTime, _spriteBatch);
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
