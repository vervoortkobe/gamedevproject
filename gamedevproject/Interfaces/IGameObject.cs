using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.Interfaces
{
    internal interface IGameObject
    {
        public Rectangle Bounds { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
