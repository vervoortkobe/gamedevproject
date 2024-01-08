using gamedevproject.GameStateClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gsman = new GameStateManager(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && _gsman.CurrentGameState is StartState)
            {
                _gsman.SetGameState(GameStates.LEVEL1);
            }

            //Press R to Restart the Current Level

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                _gsman.SetGameState(_gsman.CurrentGameState.State);
            }

            if (_gsman.IsLevelCompleted())
            {
                _gsman.SetGameState(_gsman.CurrentGameState.State + 1);
            }

            if (_gsman.HasPlayerDied())
            {
                _gsman.SetGameState(GameStates.GAMEOVER);
            }

            if (_gsman.CurrentGameState.State == GameStates.GAMEOVER && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _gsman.SetGameState(GameStates.STARTSCREEN);
            }

            if (_gsman.CurrentGameState.State == GameStates.VICTORY && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Exit();
            }

            _gsman.CurrentGameState.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            _gsman.CurrentGameState.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}