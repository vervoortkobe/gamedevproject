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
        // Textures:
        private Texture2D _texture;
        private Texture2D _blockTexture;
        private Texture2D _background;
        // Game Obj:
        private Player player;
        private Enemy enemy1;
        private List<IGameObject> blocks;
        // Other Classes:
        private Collider collider;

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
            Texture2D enemyTexture = new Texture2D(GraphicsDevice, 1, 1);
            enemyTexture.SetData(new Color[] { Color.Red });
            enemy1 = new Enemy(enemyTexture, player);
            blocks = new List<IGameObject>();
            collider = new Collider();

            for (int i = 0; i < 20; i++)
            {
                blocks.Add(new Block(_blockTexture, i * 64, 720 - 36, 64, 36));
            }

            blocks.Add(new Block(_blockTexture, 125, 720 - 140, 64, 36));
            blocks.Add(new Block(_blockTexture, 250, 720 - 190, 64, 36));
            blocks.Add(new Block(_blockTexture, 375, 720 - 240, 64, 36));
            blocks.Add(new Block(_blockTexture, 500, 720 - 315, 64, 36));
            blocks.Add(new Block(_blockTexture, 564, 720 - 315, 64, 36));
            blocks.Add(new Block(_blockTexture, 725, 720 - 254, 64, 36));
            blocks.Add(new Block(_blockTexture, 789, 720 - 254, 64, 36));
            blocks.Add(new Block(_blockTexture, 980, 720 - 240, 64, 36));
            blocks.Add(new Block(_blockTexture, 1044, 720 - 240, 64, 36));
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
            
            base.Update(gameTime);

            player.Update(gameTime);

            enemy1.Update(gameTime);
            
            collider.CheckGroundCollision(player, blocks);
            
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Rectangle(0, 0, 1280, 720),Color.White);

            // Draw blocks
            foreach(Block block in blocks)
            {
                block.Draw(_spriteBatch);
            }

            Texture2D border = new Texture2D(GraphicsDevice, 1, 1);
            border.SetData(new Color[] { Color.Red });
            _spriteBatch.Draw(border, player.Bounds, Color.Red);

            player.Draw(_spriteBatch);

            enemy1.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}