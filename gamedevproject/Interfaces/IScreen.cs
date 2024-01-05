using gamedevproject.GameStateClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.Interfaces
{
    internal interface IScreen
    {
        public void Update();
        public void Draw(SpriteBatch _spriteBatch);
    }
}
