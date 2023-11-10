using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using SharpDX.MediaFoundation;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            //Todo: Add gravity to player class or maybe game class?

            var input = movable.InputReader.ReadInput();

            movable.StateManager.CurrentState.HandleInput(input);

            // X-axis Movement

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
            
            // Y-axis Movement

            if (movable.IsJumping)
            {
                Vector2 gravity = new Vector2(0, 0.4f);
                movable.Direction += gravity;
                
                // Todo: Change to collision with ground or groundObject
                if (movable.Position.Y >= 720 - 48)
                {
                    movable.IsJumping = false;
                    movable.Direction = new Vector2(movable.Direction.X, 0);
                }
            }

            if (input == Keys.Space && !movable.IsJumping)
            {
                movable.Direction = new Vector2(movable.Direction.X, -4);
                movable.IsJumping = true;
            }

            movable.Position += movable.Direction * movable.Speed;
            
        }
    }
}
