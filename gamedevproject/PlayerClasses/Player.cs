using gamedevproject.AnimationClasses;
using gamedevproject.InputClasses;
using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using gamedevproject.MovementClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.PlayerClasses
{
    internal class Player : IMovable, IGameObject
    {
        #region Player Properties

        Animation _animation;
        
        Texture2D _playerTexture;

        Level _level;
        
        public Vector2 Position { get; set; }
        public Vector2 NewPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle Bounds { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsOnGround { get; set; }
        public bool IsAlive { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public IInputReader InputReader { get; set; }

        #endregion

        public Player(Level level, Vector2 position)
        {
            _level = level;

            LoadContent();

            ResetToStart(position);            
        }

        public void LoadContent()
        {
            _playerTexture = _level.Content.Load<Texture2D>("playerSheet");
            _animation = new Animation();

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
            spriteBatch.Draw(_playerTexture, Position, _animation.CurrentFrame.SourceRect, Color.White, 0f, new Vector2(0,0), new Vector2(1, 1), this.SpriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
            _animation.Update(gameTime);
        }

        private void Move()
        {
            MovementManager.Move(this);
        }
    }
}
