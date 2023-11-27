using gamedevproject.AnimationClasses;
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
        private Texture2D _texture;
        private Texture2D _blockTexture;
        private Texture2D _background;
        private Player player;
        private List<Block> blocks;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            player = new Player(_texture, new KeyboardReader(), this);
            blocks = new List<Block>();
            for (int i = 0; i < 20; i++)
            {
                blocks.Add(new Block(_blockTexture, i * 64, 720 - 64, 64, 36));
            }
            for (int i = 2; i < 20; i++)
            {
                if (i % 4 == 0)
                {
                    blocks.Add(new Block(_blockTexture, i * 64, 720 - 192, 64, 36));
                }
            }
            for (int i = 2; i < 20; i++)
            {
                if (i % 5 == 0)
                {
                    blocks.Add(new Block(_blockTexture, i * 64, 720 - 320, 64, 36));
                }
            }
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
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape)) 
                Exit();

            // TODO: Add your update logic here
                    
            player.IsOnGround = false;
            
            foreach (Block block in blocks)
            {
                if (player.Bounds.Intersects(block.Bounds))
                {
                    player.IsOnGround = true;
                }
            }

            player.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Rectangle(0, 0, 1280, 720),Color.White);

            Texture2D border = new Texture2D(GraphicsDevice, 1, 1);
            border.SetData(new Color[] { Color.Red });

            // Draw blocks
            foreach(Block block in blocks)
            {
                block.Draw(_spriteBatch);
                _spriteBatch.Draw(border, block.Bounds, Color.Green);
            }
          
            // Draw player
            _spriteBatch.Draw(border, player.Bounds, Color.Red);
            player.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}