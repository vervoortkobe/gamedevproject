using gamedevproject.AnimationClasses;
using gamedevproject.Interfaces;
using gamedevproject.MovementClasses;
using gamedevproject.PlayerClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.LevelObjects
{
    internal class Enemy : IMovable, IGameObject
    {
        Animation animation;

        Player Player;

        Texture2D enemyTexture;

        public int DistanceTraveled { get; set; }
        public int MaxDistance { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 NewPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Speed { get; set; }
        public Rectangle Bounds { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public bool IsOnGround { get; set; }

        public Enemy(Texture2D texture, Player player)
        {
            enemyTexture = texture;
            animation = new Animation();
            Player = player;

            //Managers
            MovementManager = new MovementManager();

            IsOnGround = false;
            Position = new Vector2(720, 720 - 84);
            Direction = new Vector2(1, 0);
            Speed = new Vector2(1, 1);

            DistanceTraveled = 0;
            MaxDistance = 320;

            Bounds = new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, Position, Bounds, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
        }

        public void Move()
        {
            Position += Direction * Speed;

            if(Position.X < Player.Position.X)
            {
                Direction = new Vector2(1, Direction.Y);
            }
            if (Position.X > Player.Position.X)
            {
                Direction = new Vector2(-1, Direction.Y);
            }
            if (Position.X == Player.Position.X)
            {
                Direction = new Vector2(0, Direction.Y);
            }
        }
        
    }
}
