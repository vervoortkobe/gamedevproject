using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var input = movable.InputReader.ReadInput();

            movable.StateManager.CurrentState.HandleInput(input);

            // Movement
            movable.Position += movable.Speed;

            // Horizontal movement (Left, Right, Stand stil)
            if (input == Keys.Right) movable.Speed = new Vector2(movable.MaxSpeed, movable.Speed.Y);
            else if (input == Keys.Left) movable.Speed = new Vector2(-movable.MaxSpeed, movable.Speed.Y);
            else movable.Speed = new Vector2(0, movable.Speed.Y);

            // Falling Logic
            if (!movable.OnGround()) movable.Speed += new Vector2(0, 1);
            else movable.Speed = new Vector2(movable.Speed.X, 0);

            // Add inbound check
        }
    }
}
