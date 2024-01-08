using gamedevproject.GameStateClasses;
using gamedevproject.LevelObjects;
using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace gamedevproject.LevelClasses
{
    internal class Level: IDisposable
    {
        #region Properties
        private LevelTile[,] tiles;
        private Rectangle[,] colliders { get; set; }

        public Player Player { get { return player; } }
        private Player player;

        public List<Enemy> Enemies { get { return enemies; } }
        private List<Enemy> enemies;

        public float Gravity = 1250f;

        private Vector2 start;
        private Vector2 spawn;
        private Point end;

        public ContentManager Content { get { return content; } }
        private ContentManager content;

        public Texture2D Background { get; set; }
        #endregion

        #region Loading
        public Level(IServiceProvider service, Stream filestream)
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

            colliders = new Rectangle[tiles.GetLength(0), tiles.GetLength(1)];

            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    char tileType = lines[y][x];
                    tiles[x, y] = LoadTile(tileType, x, y);
                    colliders[x, y] = new(x * LevelTile.Width, y * LevelTile.Height, LevelTile.Width, LevelTile.Height);
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
                case '2':
                    return LoadEndTile(x, y);
                case 'B':
                    return LoadEnemySpawnTile(x, y, EnemyType.BOWMAN);
                case 'A':
                    return LoadEnemySpawnTile(x, y, EnemyType.AXEMAN);
                case 'S':
                    return LoadEnemySpawnTile(x, y, EnemyType.SPEARMAN);
                case '#':
                    return LoadSpecificTile("Block1", 7, TileCollision.Impassable);
                default:
                    throw new NotSupportedException("Tile is not supported and / or implemented");
            }
        }

        private LevelTile LoadStartTile(int x, int y)
        {
            if (Player != null)
                throw new NotSupportedException("A level may only have one starting point.");

            Rectangle rect = GetBounds(x, y);

            start = new Vector2(rect.X, rect.Top);

            player = new Player(this, start);

            return new LevelTile(null, TileCollision.Passable);
        }

        private LevelTile LoadEnemySpawnTile(int x, int y, EnemyType enemyType)
        {
            if(Enemies == null)
            {
                enemies = new List<Enemy>();
            }

            Rectangle rect = GetBounds(x, y);

            spawn = new Vector2(rect.X, rect.Top);

            enemies.Add(new Enemy(this, spawn,enemyType));

            return new LevelTile(null, TileCollision.Passable);
        }

        private LevelTile LoadEndTile(int x, int y)
        {
            if (Player != null)
                throw new NotSupportedException("A level may only have one end point.");

            end = GetBounds(x, y).Center;

            return new LevelTile(Content.Load<Texture2D>("Sprites/exitdoor"), TileCollision.Exit);
        }

        private LevelTile LoadTileFromContent(string name, TileCollision collision)
        {
            return new LevelTile(Content.Load<Texture2D>("Sprites/" + name), collision);
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
            if (x < 0 || x >= Width)
                return TileCollision.Impassable;
            if (y < 0 || y >= Height)
                return TileCollision.Passable;

            return tiles[x, y].Collision;
        }

        public List<Rectangle> GetNearestColliders(Rectangle bounds)
        {
            int leftTile = (int)Math.Floor((float)bounds.Left / LevelTile.Width)-1;
            int rightTile = (int)Math.Ceiling((float)bounds.Right / LevelTile.Width);
            int topTile = (int)Math.Floor((float)bounds.Top / LevelTile.Height)-1;
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / LevelTile.Height);

            leftTile = MathHelper.Clamp(leftTile, 0, tiles.GetLength(1)-1);
            rightTile = MathHelper.Clamp(rightTile, 0, tiles.GetLength(1)-1);
            topTile = MathHelper.Clamp(topTile, 0, tiles.GetLength(0)-1);
            bottomTile = MathHelper.Clamp(bottomTile, 0, tiles.GetLength(0)-1);

            List<Rectangle> result = new();

            for (int x = topTile; x <= bottomTile; x++)
            {
                for (int y = leftTile; y <= rightTile; y++)
                {
                    if (tiles[y,x].Collision == TileCollision.Impassable) 
                    {
                        result.Add(colliders[y,x]);
                    }
                }
            }

            return result;
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

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            if(Enemies != null)
            {
                foreach (var enemy in Enemies)
                {
                    enemy.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);
            DrawTiles(spriteBatch);
            player.Draw(spriteBatch);
            if (Enemies != null)
            {
                foreach (var enemy in Enemies)
            
                {
                    enemy.Draw(spriteBatch);
                }
            }
            
        }

        public void Unload()
        {
            Dispose();
        }

        private void DrawTiles(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    Texture2D texture = tiles[x, y].Texture;
                    if (texture != null)
                    {
                        Vector2 position = new Vector2(x, y) * LevelTile.Size;
                        spriteBatch.Draw(texture, position, Color.White);
                    }
                }
            }
        }
    }
}
