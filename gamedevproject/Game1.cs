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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gsman = new GameStateManager(this);
        }

        protected override void Update(GameTime gameTime)
        {
            //Add GameButtons for Pausing / Exit / Restart Level
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && _gsman.CurrentGameState is StartState)
            {
                _gsman.SetGameState(GameStates.LEVEL1);
            }

            if(Keyboard.GetState().IsKeyDown(Keys.O) && _gsman.CurrentGameState is StartState)
            {
                _gsman.SetGameState(GameStates.LEVEL2);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P) && _gsman.CurrentGameState is StartState)
            {
                _gsman.SetGameState(GameStates.LEVEL3);
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