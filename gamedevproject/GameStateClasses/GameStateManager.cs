using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using gamedevproject.ScreenClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private GameState _gameState;
        private SpriteBatch _spriteBatch;
        private StartScreen _startScreen;
        private Level _level1;
        private Level _level2;
        private Level _level3;
        private VictoryScreen _victoryScreen;
        private GameOverScreen _gameOverScreen;

        #region Loading
        public GameStateManager(IServiceProvider Services, ContentManager Content, SpriteBatch spriteBatch, GameState gameState)
        {
            _gameState = gameState;
            _spriteBatch = spriteBatch;

            _startScreen = new StartScreen(Content, this, _gameState, _spriteBatch);

            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 1)))
                _level1 = new Level(Services, fileStream, 1, _gameState);

            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 2)))
                _level2 = new Level(Services, fileStream, 1, _gameState);

            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 3)))
                _level3 = new Level(Services, fileStream, 1, _gameState);

            _victoryScreen = new VictoryScreen(Content, this, _gameState, _spriteBatch);

            _gameOverScreen = new GameOverScreen(Content, this, _gameState, _spriteBatch);
        }
        #endregion

        #region Update GameState
        public void Update(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            switch (_gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    _victoryScreen.Unload();
                    _gameOverScreen.Unload();
                    _startScreen.Update(gameTime);
                    break;
                case GameStates.LEVEL1:
                    _startScreen.Unload();
                    _level1.Update(gameTime);
                    break;
                case GameStates.LEVEL2:
                    _level1.Unload();
                    _level2.Update(gameTime);
                    break;
                case GameStates.LEVEL3:
                    _level2.Unload();
                    _level3.Update(gameTime);
                    break;
                case GameStates.VICTORY:
                    _level3.Unload();
                    _victoryScreen.Update(gameTime);
                    break;
                case GameStates.GAMEOVER:
                    _level3.Unload();
                    _gameOverScreen.Update(gameTime);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Draw GameState
        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            switch (_gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    _startScreen.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.LEVEL1:
                    _level1.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.LEVEL2:
                    _level2.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.LEVEL3:
                    _level3.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.VICTORY:
                    _victoryScreen.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.GAMEOVER:
                    _gameOverScreen.Draw(gameTime, _spriteBatch);
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
