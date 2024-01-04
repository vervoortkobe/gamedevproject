using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.MapClasses
{
    public class Map
    {
        private Tileset tileset;

        int[,] mapData =
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        public Map(Texture2D tilesetTexture)
        {
            tileset = new Tileset(tilesetTexture, 48, 48);
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            for (int y = 0; y < mapData.GetLength(0); y++)
            {
                for (int x = 0; x < mapData.GetLength(1); x++)
                {
                    int tileID = mapData[y, x];

                    Vector2 position = new Vector2(x * tileset.TileWidth, y * tileset.TileHeight);

                    spriteBatch.Draw(tileset.Texture, position, new Rectangle(tileID * tileset.TileWidth, 0, tileset.TileWidth, tileset.TileHeight), Color.White);
                }
            }
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
