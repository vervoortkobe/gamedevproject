using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
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
        private Texture2D[] layers;
        private const int EntityLayer = 2;

        public Player Player { get { return player; } }
        private Player player;

        //Starting point, defined in LoadStartingTile()
        private Vector2 start;

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
            int width;
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                width = line.Length;
                while (line != null)
                {
                    lines.Add(line);
                    if (line.Length != width)
                        throw new Exception(String.Format("The length of line {0} is different from all preceeding lines.", lines.Count));
                    line = reader.ReadLine();
                }
            }

            tiles = new LevelTile[width, lines.Count];

            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    char tileType = lines[y][x];
                    tiles[x, y] = LoadTile(tileType, x, y);
                }
            }
        }

        private LevelTile LoadTile(char tileType, int x, int y)
        {
            switch (tileType)
            {
                case '.':
                    return new LevelTile(null, TileCollision.Passable);
                case '1':
                    return LoadStartTile(x, y);
                case '#':
                    return LoadSpecificTile("Ground", 7, TileCollision.Impassable);
                default:
                    throw new NotSupportedException("Tile is not supported and / or implemented");
            }
        }

        private LevelTile LoadStartTile(int x, int y)
        {
            if (Player != null)
                throw new NotSupportedException("A level may only have one starting point.");

            Rectangle rect = GetBounds(x, y);

            start = new Vector2(rect.X + rect.Width / 2.0f, rect.Bottom);

            player = new Player(this, start);

            return new LevelTile(null, TileCollision.Passable);
        }

        private LevelTile LoadTileFromContent(string name, TileCollision collision)
        {
            return new LevelTile(Content.Load<Texture2D>("Tiles/" + name), collision);
        }

        private LevelTile LoadSpecificTile(string baseName, int variationCount, TileCollision collision)
        {
            return LoadTileFromContent(baseName, collision);
        }

        public void Dispose()
        {
            Content.Unload();
        }

        #endregion

        #region Bounds and collision

        public TileCollision GetCollision(int x, int y)
        {
            // Prevent escaping past the level ends.
            if (x < 0 || x >= Width)
                return TileCollision.Impassable;
            // Allow jumping past the level top and falling through the bottom.
            if (y < 0 || y >= Height)
                return TileCollision.Passable;

            return tiles[x, y].Collision;
        }
     
        public Rectangle GetBounds(int x, int y)
        {
            return new Rectangle(x * LevelTile.Width, y * LevelTile.Height, LevelTile.Width, LevelTile.Height);
        }

        public int Width
        {
            get { return tiles.GetLength(0); }
        }

        public int Height
        {
            get { return tiles.GetLength(1); }
        }

        #endregion
    }
}
