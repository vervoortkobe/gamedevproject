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
    public class Screen: IScreen
    {
        #region Properties
        private GameStateManager _gsman;
        private GameState _gameState;
        private SpriteBatch _spriteBatch;

        private GameStates _nextGameState;

        private Texture2D _startScreenTexture;
        private Texture2D _startScreenText;
        private Texture2D _victoryTexture;
        private Texture2D _victoryText;
        private Texture2D _gameOverTexture;
        private Texture2D _gameOverText;
        #endregion

        #region Loading
        public Screen(ContentManager Content, GameStateManager gsman, GameState gameState, SpriteBatch spriteBatch)
        {
            _gsman = gsman;
            _gameState = gameState;
            _spriteBatch = spriteBatch;

            switch (_gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    _nextGameState = GameStates.LEVEL1;
                    break;
                case GameStates.LEVEL1:
                    _nextGameState = GameStates.LEVEL2;
                    break;
                case GameStates.LEVEL2:
                    _nextGameState = GameStates.LEVEL2;
                    break;
                case GameStates.LEVEL3:
                    _nextGameState = GameStates.VICTORY;
                    break;
                case GameStates.VICTORY:
                    _nextGameState = GameStates.STARTSCREEN;
                    break;
                case GameStates.GAMEOVER:
                    _nextGameState = GameStates.STARTSCREEN;
                    break;
                default:
                    break;
            }

            _startScreenTexture = Content.Load<Texture2D>("Backgrounds/startscreen2");
            _startScreenText = Content.Load<Texture2D>("Backgrounds/start2");
            _victoryTexture = Content.Load<Texture2D>("Backgrounds/extra3");
            _victoryText = Content.Load<Texture2D>("Backgrounds/victory2");
            _gameOverTexture = Content.Load<Texture2D>("Backgrounds/extra2");
            _gameOverText = Content.Load<Texture2D>("Backgrounds/gameover2");
        }
        #endregion

        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                switch (_gameState.GameStateValue)
                {
                    case GameStates.STARTSCREEN:
                        _gameState.GameStateValue = GameStates.LEVEL1;
                        break;
                    case GameStates.VICTORY:
                        _gameState.GameStateValue = GameStates.STARTSCREEN;
                        break;
                    case GameStates.GAMEOVER:
                        _gameState.GameStateValue = GameStates.STARTSCREEN;
                        break;

                    default:
                        break;
                }
            }

            if (_gameState.GameStateValue == _nextGameState)
                _gsman.Update(gameTime, _spriteBatch);
        }

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            
            switch (_gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    DrawScreen(_startScreenTexture, _startScreenText, 0.27f);
                    break;
                case GameStates.VICTORY:
                    DrawScreen(_victoryTexture, _victoryText, 0.25f);
                    break;
                case GameStates.GAMEOVER:
                    DrawScreen(_gameOverTexture, _gameOverText, 0.25f);
                    break;

                default:
                    break;
            }

            if (_gameState.GameStateValue == _nextGameState)
                _gsman.Draw(gameTime, _spriteBatch);
        }

        private void DrawScreen(Texture2D background, Texture2D text, float scaleY)
        {
            _spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);

            _spriteBatch.Draw(text, new Vector2(5, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.27f, scaleY), SpriteEffects.None, 0f);
        }

        public void Unload()
        {
            _startScreenTexture.Dispose();
            _startScreenText.Dispose();
            _victoryTexture.Dispose();
            _victoryText.Dispose();
            _gameOverTexture.Dispose();
            _gameOverText.Dispose();
        }
    }
}
