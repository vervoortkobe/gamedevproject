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
        
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public float MaxSpeed { get; set; } = 10;
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public IInputReader InputReader { get; set; }

        public Player(Texture2D texture, IInputReader inputReader)
        {
            playerTexture = texture;
            InputReader = inputReader;
            animation = new Animation();
            MovementManager = new MovementManager();
            StateManager = new StateManager(this);

            Position = new Vector2(0, 480-48);
            Speed = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }

        private void Move()
        {
            MovementManager.Move(this);
        }

        public bool OnGround()
        {
            // returns false if the Y position of the movable is greater than the bottom of the game - the height of the movable
            return Position.Y >= 480 - 48;
        }
    }
}
