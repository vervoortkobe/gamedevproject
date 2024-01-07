using gamedevproject.GameStateClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject.ScreenClasses
{
    internal class Screen: IScreen
    {
        #region Properties
        private ContentManager _content;
        private GameStateManager _gsman;
        private GameState _gameState;
        private SpriteBatch _spriteBatch;

        private GameStates compareGameStates;

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
            _content = Content;
            _gsman = gsman;
            _gameState = gameState;
            _spriteBatch = spriteBatch;

            compareGameStates = _gameState.GameStateValue;

            _startScreenTexture = _content.Load<Texture2D>("Backgrounds/startscreen2");
            _startScreenText = _content.Load<Texture2D>("Backgrounds/start2");
            _victoryTexture = _content.Load<Texture2D>("Backgrounds/extra3");
            _victoryText = _content.Load<Texture2D>("Backgrounds/victory2");
            _gameOverTexture = _content.Load<Texture2D>("Backgrounds/extra2");
            _gameOverText = _content.Load<Texture2D>("Backgrounds/gameover2");
        }
        #endregion

        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
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

            if (compareGameStates != _gameState.GameStateValue)
                _gsman.Update(gameTime, _spriteBatch);
        }
        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            Texture2D background = null;
            Texture2D text = null;
            float scaleY = 0.0f;
            
            switch (_gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    background = _startScreenTexture;
                    text = _startScreenText;
                    scaleY = 0.27f;
                    break;
                case GameStates.VICTORY:
                    background = _victoryTexture;
                    text = _victoryText;
                    scaleY = 0.25f;
                    break;
                case GameStates.GAMEOVER:
                    background = _gameOverTexture;
                    text = _gameOverText;
                    scaleY = 0.25f;
                    break;

                default:
                    break;
            }

            _spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);

            _spriteBatch.Draw(text, new Vector2(5, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.27f, scaleY), SpriteEffects.None, 0f);

            if (compareGameStates != _gameState.GameStateValue)
                _gsman.Draw(gameTime, _spriteBatch);
        }

        public void Unload()
        {
            _content.Dispose();
        }
    }
}
