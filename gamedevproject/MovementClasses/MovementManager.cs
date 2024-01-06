using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using SharpDX.MediaFoundation;
using gamedevproject.LevelClasses;
using SharpDX.Direct2D1.Effects;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {

        public float Gravity = 15f;

        Level level;

        public MovementManager(Level level)
        {
            this.level = level;
        }

        public void Move(IMovable movable, Level level, GameTime gameTime)
        {
            //Todo: Add gravity to player class or maybe game class?

            var input = movable.InputReader.ReadInput();

            movable.StateManager.CurrentState.HandleInput(input);

            float velocityX = movable.Direction.X;
            float velocityY = movable.Direction.Y;

            // X-axis Movement

            if (input == Keys.None)
            {
                velocityX = 0;
            }

            if (input == Keys.Right)
            {
                movable.SpriteEffects = SpriteEffects.None;
                velocityX = 25.0f;
            }

            if (input == Keys.Left)
            {
                movable.SpriteEffects = SpriteEffects.FlipHorizontally;
                velocityX = -25.0f;
            }

            //Gravity working on the player
            velocityY += Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (input == Keys.Space)
            {
                if (velocityY == 0)
                {
                    velocityY = -25.0f;
                    movable.IsOnGround = true;
                }
            }

            Vector2 velocity = new Vector2(velocityX, velocityY);

            movable.NewPosition = movable.Position + velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //CheckCollisions(level, movable);

            movable.Position = movable.NewPosition;
        }

        public void CheckCollisions(Level level, IMovable movable)
        {
            //Check X Collision

            Vector2 positionInTiles = new Vector2(movable.Position.X / LevelTile.Width, movable.Position.Y / LevelTile.Height);
            Vector2 newPositionInTiles = new Vector2(movable.NewPosition.X / LevelTile.Width, movable.NewPosition.Y / LevelTile.Height);

            if (movable.Direction.X <= 0)
            {
                if (level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(positionInTiles.Y + 0.0f)) == TileCollision.Impassable
                    || level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(positionInTiles.Y + 0.9f)) == TileCollision.Impassable)
                {
                    movable.NewPosition = new Vector2((int)movable.NewPosition.X + 1, movable.Position.Y);
                    movable.Direction = new Vector2(0, movable.Direction.Y);
                }
            }
            else
            {
                if (level.GetCollision((int)(newPositionInTiles.X + 1.0f), (int)(positionInTiles.Y + 0.0f)) == TileCollision.Impassable
                    || level.GetCollision((int)(newPositionInTiles.X + 1.0f), (int)(positionInTiles.Y + 0.9f)) == TileCollision.Impassable)
                {
                    movable.NewPosition = new Vector2((int)movable.NewPosition.X, movable.Position.Y);
                    movable.Direction = new Vector2(0, movable.Direction.Y);
                }
            }

            //Recalculate the position in tiles with the new x position

            newPositionInTiles = new Vector2(movable.NewPosition.X / LevelTile.Width, movable.NewPosition.Y / LevelTile.Height);

            //Check Y Collision

            if (movable.Direction.Y <= 0)
            {
                if (level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(newPositionInTiles.Y + 0.0f)) == TileCollision.Impassable
                    || level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(newPositionInTiles.Y + 0.9f)) == TileCollision.Impassable)
                {
                    movable.NewPosition = new Vector2(movable.NewPosition.X, (int)movable.Position.Y + 1);
                    movable.Direction = new Vector2(movable.Direction.X, 0);
                }
            }
            else
            {
                if (level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(newPositionInTiles.Y + 0.0f)) == TileCollision.Impassable
                    || level.GetCollision((int)(newPositionInTiles.X + 0.0f), (int)(newPositionInTiles.Y + 0.9f)) == TileCollision.Impassable)
                {
                    movable.NewPosition = new Vector2(movable.NewPosition.X, (int)movable.Position.Y);
                    movable.Direction = new Vector2(movable.Direction.X, 0);
                }
            }
        }
    }
}
