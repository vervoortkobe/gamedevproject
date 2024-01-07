using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.LevelObjects
{
    internal class Block: IGameObject
    {
        public Rectangle Bounds { get; set; }

        public Texture2D Texture { get; set; }

        public Block(Texture2D texture,int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
            Texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Bounds,Color.White);
        }
    }
}
