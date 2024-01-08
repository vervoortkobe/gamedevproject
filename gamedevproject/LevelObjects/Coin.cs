using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.LevelObjects
{
    internal class Coin : IGameObject
    {
        private Texture2D Texture;

        public Level Level { get; private set; }

        public Vector2 Position { get; set; }
        
        public Rectangle Bounds { get; set; }

        public Coin(Level level, Vector2 position)
        {
            this.Level = level;

            this.Position = position;

            LoadContent();
        }

        public void LoadContent()
        {
            Texture = Level.Content.Load<Texture2D>("Sprites/Coin");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
