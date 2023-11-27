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

        public Vector2 Gravity = new Vector2(0, 0.2f);

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

            if (input == Keys.Space && movable.IsOnGround)
            {
                movable.IsOnGround = false;
                movable.Direction = new Vector2(movable.Direction.X, -8);
            }

            if (movable.IsOnGround)
            {
                movable.Direction = new Vector2(movable.Direction.X, 0);
            }
            else
            {
                movable.Direction += Gravity;
            }

            movable.Position += movable.Direction * movable.Speed;
        }
    }
}
