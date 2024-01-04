using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.Interfaces
{
    internal interface IGameObject
    {
        public Rectangle Bounds { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
