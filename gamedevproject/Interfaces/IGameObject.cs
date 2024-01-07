using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.Interfaces
{
    internal interface IGameObject
    {
        public Rectangle Bounds { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
