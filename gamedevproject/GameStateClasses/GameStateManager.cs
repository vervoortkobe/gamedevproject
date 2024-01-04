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

    internal class GameStateManager
    {
        private IGameState gameState { get; set; }
        private Level _level;
        private readonly IServiceProvider Services;

        public GameStateManager()
        {
            return;
        }

        public GameStateManager(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void ExecuteGameState()
        {
            switch (gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    string levelPath = string.Format("Content/Levels/Level{0}", 1);
                    using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                        _level = new Level(Services, fileStream, 1);
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

        public void Update(GameTime gameTime)
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

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
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
