using gamedevproject.GameStateClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject.ScreenClasses
{
    public class VictoryScreen: IScreen
    {
        private GameStateManager _gsman;
        private GameState _gameState;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Texture2D _text;

        public VictoryScreen(ContentManager Content, GameStateManager gsman, GameState gameState, SpriteBatch spriteBatch)
        {
            _gsman = gsman;
            _gameState = gameState;
            _spriteBatch = spriteBatch;
            _texture = Content.Load<Texture2D>("Backgrounds/extra3");
            _text = Content.Load<Texture2D>("Backgrounds/victory2");
        }

        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
                _gameState.GameStateValue = GameStates.STARTSCREEN;

            if (_gameState.GameStateValue == GameStates.STARTSCREEN)
                _gsman.Update(gameTime, _spriteBatch);
        }

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);

            _spriteBatch.Draw(_text, new Vector2(5, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.25f, 0.25f), SpriteEffects.None, 0f);

            if (_gameState.GameStateValue == GameStates.STARTSCREEN)
                _gsman.Draw(gameTime, _spriteBatch);
        }

        public void Unload()
        {
            _texture.Dispose();
            _text.Dispose();
        }
    }
}
