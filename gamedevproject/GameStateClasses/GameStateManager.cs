using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace gamedevproject.GameStateClasses
{
    public enum GameStates
    {
        STARTSCREEN, LEVEL1, LEVEL2, LEVEL3, VICTORY, GAMEOVER
    }

    public class GameStateManager
    {
        public List<GameState> GameStates { get; set; }

        public GameState CurrentGameState { get; set; }

        public Game Game { get; set; }

        #region Loading
        public GameStateManager(Game game)
        {
            //_gameState = gameState;
            //_spriteBatch = spriteBatch;

            //_startScreen = new StartScreen(Content, this, _gameState, _spriteBatch);

            //using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 1)))
            //    _level1 = new Level(Services, fileStream, _gameState);

            //using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 2)))
            //    _level2 = new Level(Services, fileStream, _gameState);

            //using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 3)))
            //    _level3 = new Level(Services, fileStream, _gameState);

            //_victoryScreen = new VictoryScreen(Content, this, _gameState, _spriteBatch);

            //_gameOverScreen = new GameOverScreen(Content, this, _gameState, _spriteBatch);

            this.Game = game;

            GameStates = new List<GameState>
            {
                new StartState(Game),
                new LevelState(Game),
                new LevelState(Game),
                new LevelState(Game),
            };

            CurrentGameState = GameStates[0];
            CurrentGameState.Enter(GameStateClasses.GameStates.STARTSCREEN);
        }
        #endregion

        public void SetGameState(GameStates state)
        {
            CurrentGameState = GameStates[(int)state];
            CurrentGameState.Enter(state);
        }

        #region Update GameState
        public void Update(GameTime gameTime)
        {
            CurrentGameState.Update(gameTime);
        }
        #endregion

        #region Draw GameState
        public void Draw(SpriteBatch _spriteBatch)
        {
            CurrentGameState.Draw(_spriteBatch);
        }
        #endregion
    }
}
