using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.LevelClasses
{
    internal class Level: IDisposable
    {
        #region Properties

        private LevelTile[,] tiles;
        private Texture2D[] layer;
        private const int EntityLayer = 2;

        public Player Player { get { return player; } }
        private Player player;

        public ContentManager Content { get { return content; } }
        private ContentManager content;

        #endregion

        #region Loading

        public Level(IServiceProvider service, Stream filestream, int levelIndex)
        {
            content = new ContentManager(service, "Content");

            LoadTiles(filestream);
        }

        private void LoadTiles(Stream fileStream)
        {

        }

        private LevelTile LoadTile(char tileType, int x, int y)
        {
            switch (tileType)
            {
                case '.':
                    return new LevelTile();
                default:
                    throw new NotSupportedException("Tile is not supported.");
            }
        }

        public void Dispose()
        {
            Content.Unload();
        }
        
        #endregion
    }
}
