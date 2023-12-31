﻿using gamedevproject.GameStateClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameState _gameState;
        private GameStateManager _gsman;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            //Screen Dimensions:
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _gameState = new GameState();
            _gameState.GameStateValue = GameStates.STARTSCREEN;
            _gsman = new GameStateManager(Services, Content, _spriteBatch, _gameState);
        }

        protected override void Update(GameTime gameTime)
        {
            //Add GameButtons for Pausing / Exit / Restart Level
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            _gsman.Update(gameTime, _spriteBatch);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            _gsman.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}