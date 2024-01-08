﻿using gamedevproject.Interfaces;
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
            this.Game = game;

            GameStates = new List<GameState>
            {
                new StartState(Game),
                new LevelState(Game,GameStateClasses.GameStates.LEVEL1),
                new LevelState(Game,GameStateClasses.GameStates.LEVEL2),
                new LevelState(Game,GameStateClasses.GameStates.LEVEL3),
            };

            CurrentGameState = GameStates[0];
            CurrentGameState.Enter();
        }
        #endregion

        public void SetGameState(GameStates state)
        {
            CurrentGameState = GameStates[(int)state];
            CurrentGameState.Enter();
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

        public bool IsLevelCompleted()
        {
            if(CurrentGameState.State == GameStateClasses.GameStates.LEVEL1){
                return CurrentGameState.Level.Player.HasReachedExit;
            }
            else
               return false;
        }
    }
}
