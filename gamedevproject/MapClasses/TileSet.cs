using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.MapClasses
{
    public class Tileset
    {
        public Texture2D Texture { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        // Add any other properties you need

        public Tileset(Texture2D texture, int tileWidth, int tileHeight)
        {
            Texture = texture;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }
    }
}
