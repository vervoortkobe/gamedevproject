using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            //Todo: Add gravity to player class or maybe game class?

            Vector2 gravity = new Vector2(0, 0.4f);

            var input = movable.InputReader.ReadInput();

            movable.StateManager.CurrentState.HandleInput(input);

            movable.Position += movable.Direction * movable.Speed;

            if (input == Keys.None)
            {
                movable.Direction = new Vector2(0, movable.Direction.Y);
            }

            if (input == Keys.Right)
            {
                movable.SpriteEffects = SpriteEffects.None;
                movable.Direction = new Vector2(1, movable.Direction.Y);
            }

            if (input == Keys.Left)
            {
                movable.SpriteEffects = SpriteEffects.FlipHorizontally;
                movable.Direction = new Vector2(-1, movable.Direction.Y);
            }
            
            // Jumping Logic

            if(input == Keys.Space && movable.OnGround())
            {
                movable.Direction = new Vector2(movable.Direction.X, -5);
            }

            // Falling Logic
            // Todo: Change OnGround() to IsJumping()?

            else if (!movable.OnGround())
            {
                movable.Direction += gravity;
            }

            // Todo: Change to collision with ground or groundObject

            else if(movable.Position.Y >= 480 - 48)
            {
                movable.Direction = new Vector2(movable.Direction.X, 0);
            }

            

            // Todo: Add inbound check
        }
    }
}
