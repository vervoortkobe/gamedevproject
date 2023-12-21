using gamedevproject.AnimationClasses;
using gamedevproject.HelperClasses;
using gamedevproject.InputClasses;
using gamedevproject.Interfaces;
using gamedevproject.LevelObjects;
using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace gamedevproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            //Game Dimensions:
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        private void InitializeGameObjects()
        {
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _texture = Content.Load<Texture2D>("playerSheet");
            _blockTexture = Content.Load<Texture2D>("block-texture2");
            _background = Content.Load<Texture2D>("background1");

            InitializeGameObjects();
        }

        protected override void Update(GameTime gameTime)
        {
            //Add GameButtons for Pausing / Exit / Restart Level

            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape)) 
                Exit();
            
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            // Level.Draw()

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}