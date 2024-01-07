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

        public Animation animation;
        
        Texture2D playerTexture;

        Level level;
        
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle Bounds 
        { 
            get 
            {
                int left = (int)Math.Round(Position.X);
                int top = (int)Math.Round(Position.Y);
                return new Rectangle(left, top, 48, 48);
            } 
        }
        public float Speed { get; set; }
        public bool IsOnGround { get; set; }
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

            InputReader = new KeyboardReader();
            MovementManager = new MovementManager(level);
            
            StateManager = new StateManager(this);
        }

        public void ResetToStart(Vector2 position)
        {
            Position = position;
            IsAlive = true;
            IsOnGround = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White, 0f, new Vector2(0,0), new Vector2(1, 1), this.SpriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            MovementManager.Move(this, level, gameTime);
        }
    }
}
