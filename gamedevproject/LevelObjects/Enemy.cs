using gamedevproject.AnimationClasses;
using gamedevproject.InputClasses;
using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using gamedevproject.MovementClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gamedevproject.LevelObjects
{
    internal class Enemy : IMovable, IGameObject
    {
        Animation animation;

        Texture2D enemyTexture;

        Level level;

        public int DistanceTraveled { get; set; }
        public int MaxDistance { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Rectangle Bounds
        {
            get
            {
                int left = (int)Math.Round(Position.X);
                int top = (int)Math.Round(Position.Y);
                return new Rectangle(left, top, 48, 48);
            }
        }
        public SpriteEffects SpriteEffects { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public bool IsOnGround { get; set; }

        public Enemy(Level level, Vector2 position)
        {
            this.level = level;

            LoadContent();

            Position = position;
            IsOnGround = false;
            Direction = new Vector2(0, 0);
            Speed = 1.0f;

            DistanceTraveled = 0;
            MaxDistance = 320;
        }

        public void LoadContent()
        {
            //Sprite aanpassen naar Enemy Sprite, liefst 3 verschillende;
            enemyTexture = level.Content.Load<Texture2D>("Sprites/Block1");

            animation = new Animation();

            MovementManager = new MovementManager(level);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, Position, Bounds, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            Position += Direction * Speed;

            if(Position.X < level.Player.Position.X)
            {
                Direction = new Vector2(1, Direction.Y);
                SpriteEffects = SpriteEffects.None;
            }
            if (Position.X > level.Player.Position.X)
            {
                Direction = new Vector2(-1, Direction.Y);
                SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (Position.X == level.Player.Position.X)
            {
                Direction = new Vector2(0, Direction.Y);
            }

            //CollisionCheck implementeren
            MovementManager.UpdatePosition(level, this, gameTime);

        }
    }
}
