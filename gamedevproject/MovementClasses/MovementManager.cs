using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
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
            var m = movable;
            var direction = m.InputReader.ReadInput();
            direction *= m.Speed;
            m.Position += direction;
            m.Speed += m.Acceleration;
            m.Speed = Limit(m.Speed, m.MaxSpeed);

            /*if (movable.InputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * movable.Velocity;
            var futurePosition = movable.Position + distance;
            movable.Position = futurePosition;
            movable.Position += distance;*/

            if (m.Position.X > 800 - 48 || m.Position.X < 0) // bots x
            {
                m.Speed = new Vector2(m.Speed.X * -1, m.Speed.Y);
                m.Acceleration = new Vector2(m.Acceleration.X * -1, m.Acceleration.Y);
            }
            if(m.Position.Y > 480 - 48 || m.Position.Y < 0) // bots y
            {
                m.Speed = new Vector2(m.Speed.X, m.Speed.Y * -1);
                m.Acceleration = new Vector2(m.Acceleration.X, m.Acceleration.Y * -1);
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
    }
}
