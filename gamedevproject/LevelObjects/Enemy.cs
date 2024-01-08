using gamedevproject.AnimationClasses;
using gamedevproject.InputClasses;
using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using gamedevproject.MovementClasses;
using gamedevproject.PlayerClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gamedevproject.LevelObjects
{
    internal enum EnemyType
    {
        BOWMAN,AXEMAN,SPEARMAN 
    }
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

        public Enemy(Level level, Vector2 position, EnemyType enemyType)
        {
            this.level = level;

            LoadContent(enemyType);

            MovementManager = new MovementManager(level);

            Position = position;
            IsOnGround = false;
            Direction = new Vector2(0, 0);
            Speed = 1.0f;

            DistanceTraveled = 0;
            MaxDistance = 320;
        }

        public void LoadContent(EnemyType enemyType)
        {

            switch (enemyType)
            {
                case EnemyType.BOWMAN:
                    enemyTexture = level.Content.Load<Texture2D>("Sprites/enemy1");

                    animation = new Animation();
                    animation.maxFrames = 13;
                    animation.frameY = 3;
                    animation.GetFrames(48, 48);
                    break;
                case EnemyType.AXEMAN:
                    enemyTexture = level.Content.Load<Texture2D>("Sprites/enemy3");

                    animation = new Animation();
                    animation.maxFrames = 6;
                    animation.frameY = 4;
                    animation.GetFrames(48, 48);
                    break;
                case EnemyType.SPEARMAN:
                    enemyTexture = level.Content.Load<Texture2D>("Sprites/enemy2");

                    animation = new Animation();
                    animation.maxFrames = 6;
                    animation.frameY = 4;
                    animation.GetFrames(48, 48);
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, Position, animation.CurrentFrame.SourceRect, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            float velocityX = Direction.X;
            float velocityY = Direction.Y;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.X < level.Player.Position.X)
            {
                SpriteEffects = SpriteEffects.None;
                velocityX += 200f * deltaTime;
            }
            if (Position.X > level.Player.Position.X)
            {
                SpriteEffects = SpriteEffects.FlipHorizontally;
                velocityX += -200f * deltaTime;
            }
            if (Position.X == level.Player.Position.X)
            {
                velocityX = 0;
            }

            //Set max speed along the X-axis left and right
            MathHelper.Clamp(velocityX, -0.5f, 0.5f);

            velocityY += level.Gravity * deltaTime;

            Direction = new Vector2(velocityX, velocityY);

            MovementManager.UpdatePosition(level, this, gameTime);

        }
    }
}
