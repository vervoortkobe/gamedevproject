using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {

        public Vector2 Gravity = new Vector2(0, 0.5f);

        public void Move(IMovable movable)

        public float Gravity = 1250f;

        Level level;

        public MovementManager(Level level)
        {
            this.level = level;
        }

        public void Move(IMovable player, Level level, GameTime gameTime)
        {

            var input = movable.InputReader.ReadInput();
            var input = player.InputReader.ReadInput();
            
            player.StateManager.CurrentState.HandleInput(input);

            float velocityX = player.Direction.X;
            float velocityY = player.Direction.Y;

            Vector2 prevPosition = movable.Position;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // X-axis Movement

            if (input == Keys.None)
            {
                velocityX = 0;
            }

            if (input == Keys.Right)
            {
                player.SpriteEffects = SpriteEffects.None;
                velocityX += 350.0f * deltaTime;
            }

            if (input == Keys.Left)
            {
                player.SpriteEffects = SpriteEffects.FlipHorizontally;
                velocityX += -350.0f * deltaTime;
            }

            movable.Position += movable.Direction;

            // Y-axis Movement

            velocityY += Gravity * deltaTime; 
            
            if (input == Keys.Space && player.IsOnGround)
            {
                velocityY = -500.0f;
            }

            player.Direction = new Vector2(velocityX, velocityY);

            UpdatePosition(level, player, gameTime);
            
        }

            if (!movable.IsOnGround)
            {
                movable.Direction += Gravity;
            }
        public void UpdatePosition(Level level, IMovable player, GameTime gameTime)
        {
            player.IsOnGround = false;

            if (input == Keys.Space && movable.IsOnGround)
            var newPosition = player.Position + player.Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Rectangle newBounds = new Rectangle((int)newPosition.X, (int)newPosition.Y,48,48);

            foreach (var collider in level.GetNearestColliders(newBounds))
            {
                movable.Direction = new Vector2(movable.Direction.X, -10);
            }
                if (newPosition.X != player.Position.X)
                {
                    newBounds = new Rectangle((int)newPosition.X, (int)player.Position.Y,48,48);
                    if (newBounds.Intersects(collider))
                    {
                        if (newPosition.X > player.Position.X) newPosition.X = collider.Left - 48;
                        else newPosition.X = collider.Right;
                        continue;
                    }
                }

            movable.Direction.Normalize();
                newBounds = new Rectangle((int)player.Position.X, (int)newPosition.Y,48,48);
                if (newBounds.Intersects(collider))
                {
                    if (player.Direction.Y > 0)
                    {
                        newPosition.Y = collider.Top - 48;
                        player.IsOnGround = true;
                        player.Direction = new Vector2(player.Direction.X, 0);
                    }
                    else
                    {
                        newPosition.Y = collider.Bottom;
                        player.Direction = new Vector2(player.Direction.X, 0);
                    }
                }
            }
            player.Position = newPosition;
        }
    }
}
