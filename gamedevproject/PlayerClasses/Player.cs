using gamedevproject.AnimationClasses;
using gamedevproject.Interfaces;
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
        public Animation animation;
        
        Texture2D playerTexture;

        Game _game;
        
        public Vector2 Position { get; set; }
        public Vector2 NewPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle Bounds { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsOnGround { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public IInputReader InputReader { get; set; }

        public Player(Texture2D texture, IInputReader inputReader, Game game)
        {
            _game = game;
            playerTexture = texture;
            InputReader = inputReader;
            animation = new Animation();

            //Managers
            MovementManager = new MovementManager();
            StateManager = new StateManager(this);

            IsOnGround = false;
            Position = new Vector2(30, 720-200);
            Direction = new Vector2(0,0);
            Speed = new Vector2(3,1);

            Bounds = new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
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
