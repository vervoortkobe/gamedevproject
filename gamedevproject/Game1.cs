using gamedevproject.AnimationClasses;
using gamedevproject.InputClasses;
using gamedevproject.MapClasses;
using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Player player;
        Texture2D _tilesetTexture;
        private Map map;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            player = new Player(_texture, new KeyboardReader());
            map = new Map(_tilesetTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _texture = Content.Load<Texture2D>("playerSheet");
            //_texture = Content.Load<Texture2D>("CharacterSheet");

            _tilesetTexture = Content.Load<Texture2D>("TextureSheet");

            InitializeGameObjects();
        }

        protected override void Update(GameTime gameTime)
        {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape)) 
                Exit();

            // TODO: Add your update logic here
            //map.Update(gameTime);
            player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}