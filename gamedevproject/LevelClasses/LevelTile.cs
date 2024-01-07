using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.LevelClasses
{
    enum TileCollision
    {
        Passable,
        Impassable,
        Platform,
        OneWayLeft,
        OneWayRight,
        InversePlatform
    }

    internal class LevelTile
    {
        public Texture2D Texture;
        public TileCollision Collision;

        public const int Width = 48;
        public const int Height = 48;

        public static readonly Vector2 Size = new Vector2(Width, Height);

        public LevelTile(Texture2D texture, TileCollision collision)
        {
            Texture = texture;
            Collision = collision;
        }
    }
}
