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
        IDLE,PATROL,SEEKER 
    }
    internal class Enemy : IMovable, IGameObject
    {
        Animation animation;

        Texture2D Texture;

        EnemyType EnemyType;

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

            this.EnemyType = enemyType;

            LoadContent();

            MovementManager = new MovementManager(level);

            Position = position;
            IsOnGround = false;
            Direction = new Vector2(0, 0);
            Speed = 1.0f;

            DistanceTraveled = 0;
            MaxDistance = 96;
        }

        public void LoadContent()
        {

            switch (EnemyType)
            {
                case EnemyType.IDLE:
                    Texture = level.Content.Load<Texture2D>("Sprites/Enemy1");

                    animation = new Animation();
                    animation.maxFrames = 1;
                    animation.frameY = 0;
                    animation.GetFrames(48, 48);
                    break;
                case EnemyType.PATROL:
                    Texture = level.Content.Load<Texture2D>("Sprites/Enemy2");

                    animation = new Animation();
                    animation.maxFrames = 6;
                    animation.frameY = 1;
                    animation.GetFrames(48, 48);
                    break;
                case EnemyType.SEEKER:
                    Texture = level.Content.Load<Texture2D>("Sprites/Enemy3");

                    animation = new Animation();
                    animation.maxFrames = 6;
                    animation.frameY = 1;
                    animation.GetFrames(48, 48);
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, animation.CurrentFrame.SourceRect, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects, 0f);
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

            switch (EnemyType)
            {
                case EnemyType.IDLE:
                case EnemyType.PATROL:
                    if (Position.X < level.Player.Position.X)
                    {
                        SpriteEffects = SpriteEffects.FlipHorizontally;
                    }
                    if (Position.X > level.Player.Position.X)
                    {
                        SpriteEffects = SpriteEffects.None;
                    }
                    break;
                case EnemyType.SEEKER:

                    if (Position.X < level.Player.Position.X)
                    {
                        SpriteEffects = SpriteEffects.FlipHorizontally;
                        velocityX += 200f * deltaTime;
                    }
                    if (Position.X > level.Player.Position.X)
                    {
                        SpriteEffects = SpriteEffects.None;
                        velocityX += -200f * deltaTime;
                    }
                    if (Position.X == level.Player.Position.X)
                    {
                        velocityX = 0;
                    }

                    //Set max speed along the X-axis left and right
                    MathHelper.Clamp(velocityX, -0.25f, 0.25f);
                    break;
                default:
                    break;
            }

            

            velocityY += level.Gravity * deltaTime;

            Direction = new Vector2(velocityX, velocityY);

            MovementManager.UpdatePosition(level, this, gameTime);

        }
    }
}
