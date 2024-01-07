using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace gamedevproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Level _level;

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

            string levelPath = string.Format("Content/Levels/Level{0}.txt", 1);
            using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                _level = new Level(Services, fileStream, 1);
        }

        protected override void Update(GameTime gameTime)
        {
            //Add GameButtons for Pausing / Exit / Restart Level

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _level.Update(gameTime);
            
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            _level.Draw(gameTime,_spriteBatch);

            // DrawHUD()

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}