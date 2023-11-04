using gamedevproject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.MovementClasses
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            /*var direction = InputReader.ReadInput();
            direction *= Velocity;
            Position += direction;*/

            var direction = movable.InputReader.ReadInput();

            /*if (movable.InputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }*/

            var distance = direction * movable.Velocity;
            var futurePosition = movable.Position + distance;
            movable.Position = futurePosition;
            movable.Position += distance;
        }

    }
}
