using gamedevproject.GameStateClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.Interfaces
{
    internal interface IScreen
    {
        public void Update(GameTime gameTime);

        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch);
    }
}
