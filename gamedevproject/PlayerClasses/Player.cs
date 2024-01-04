using gamedevproject.AnimationClasses;
using gamedevproject.InputClasses;
using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using gamedevproject.MovementClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.PlayerClasses
{
    internal class Player : IMovable, IGameObject
    {
        #region Player Properties

        public Animation animation;
        
        Texture2D playerTexture;

        Level level;
        
        public Vector2 Position { get; set; }
        public Vector2 NewPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle Bounds { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsOnGround { get; set; } = true;
        public bool IsAlive { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public IInputReader InputReader { get; set; }

        #endregion

        public Player(Level level, Vector2 position)
        {
            this.level = level;

            LoadContent();

            ResetToStart(position);            
        }

        public void LoadContent()
        {
            playerTexture = level.Content.Load<Texture2D>("Sprites/PlayerSheet");
            animation = new Animation();

            //Managers & Readers
            InputReader = new KeyboardReader();
            MovementManager = new MovementManager();
            //Animation is assigned and updated inside the StateManager
            StateManager = new StateManager(this);
        }

        public void ResetToStart(Vector2 position)
        {
            Position = position;
            Direction = Vector2.Zero;
            IsAlive = true;
            // Implement: set state to idle 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White, 0f, new Vector2(0,0), new Vector2(1, 1), this.SpriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
            animation.Update(gameTime);
        }

        private void Move()
        {
            MovementManager.Move(this);
        }
    }
}
