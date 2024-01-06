using gamedevproject.GameStateClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata;

namespace gamedevproject.ScreenClasses
{
    internal class StartScreen : IScreen
    {
        private GameStateManager _gsman;
        private GameState _gameState;
        private SpriteBatch _spriteBatch;
        private Texture2D _startTexture;
        private Texture2D _start;

        public StartScreen(ContentManager Content, GameStateManager gsman, GameState gameState, SpriteBatch spriteBatch)
        {
            _gsman = gsman;
            _gameState = gameState;
            _spriteBatch = spriteBatch;
            _startTexture = Content.Load<Texture2D>("Backgrounds/startscreen2");
            _start = Content.Load<Texture2D>("Backgrounds/start2");
        }

        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _gameState.GameStateValue = GameStates.LEVEL1;
                _gsman.Update(gameTime, _spriteBatch, _gameState);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_startTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);

            _spriteBatch.Draw(_start, new Vector2(5, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.27f, 0.25f), SpriteEffects.None, 0f);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _gsman.Draw(gameTime, _spriteBatch, _gameState);
            }
        }
    }
}
