using gamedevproject.AnimationClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace gamedevproject.PlayerClasses
{
    internal class Player : IMovable, IGameObject
    {
        public Animation animation;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration = new Vector2(0.1f, 0.1f);
        
        public float maxVelocity = 10;

        Texture2D playerTexture;

        public Player(Texture2D texture)
        {
            playerTexture = texture;

            animation = new Animation();
            animation.GetFramesFromTexture(texture.Width, texture.Height, 10, 1);

            Position = new Vector2(0, 0);
            Velocity = new Vector2(1, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //scale x2
            //spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
        }

        private void Move()
        {
            Position += Velocity;
            Velocity += Acceleration;

            Velocity = Limit(Velocity, maxVelocity);

            if (Position.X > 800 - 48 || Position.X < 0) {
                Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
                Acceleration.X *= -1;
            }
            if (Position.Y > 480 - 48 || Position.Y < 0)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
                Acceleration.Y *= -1;
            }
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
