using gamedevproject.AnimationClasses;
using gamedevproject.Interfaces;
using gamedevproject.MovementClasses;
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
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float maxVelocity = 10;
        Texture2D playerTexture;
        public IInputReader InputReader { get; set; }
        private MovementManager movementManager = new MovementManager();


        public Player(Texture2D texture, IInputReader inputReader)
        {
            this.playerTexture = texture;
            this.InputReader = inputReader;

            animation = new Animation();
            animation.GetFramesFromTexture(texture.Width, texture.Height, 10, 1);

            Position = new Vector2(1, 1);
            Velocity = new Vector2(2, 2);
            Acceleration = new Vector2(0.1f, 0.1f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //scale x2
            //spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White, 0, Vector2.Zero, 3, SpriteEffects.None, 0);
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

    }
}
