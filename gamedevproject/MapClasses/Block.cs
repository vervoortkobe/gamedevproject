using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.MapClasses
{
    public class Block
    {
        private int tileId { get; set; }
        private Vector2 position { get; set; }

        public Block(int tileId, Vector2 position)
        {
            this.tileId = tileId;
            this.position = position;
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D t)
        {

        }
    }
}
