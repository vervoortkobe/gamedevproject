using gamedevproject.AnimationClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        Texture2D playerTexture;

        public Player(Texture2D texture)
        {
            playerTexture = texture;

            animation = new Animation();
            animation.GetFramesFromTexture(texture.Width, texture.Height, 10, 1);

            Position = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, Position, animation.CurrentFrame.SourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
