using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace gamedevproject.HelperClasses
{
    internal class Collider
    {
        public void CheckGroundCollision(IMovable movable, List<IGameObject> gameObjectList)
        {
            movable.NewPosition = movable.Position + movable.Direction * movable.Speed;

            movable.IsOnGround = false;

            foreach (var gameObject in gameObjectList)
            {
                if (movable.NewPosition.X != movable.Position.X)
                {
                    if(new Rectangle((int)movable.NewPosition.X,(int)movable.Position.Y, 48, 48).Intersects(gameObject.Bounds)){
                        if(movable.NewPosition.X > movable.Position.X)
                        {
                            movable.NewPosition = new Vector2(gameObject.Bounds.Left - movable.Bounds.Width, movable.NewPosition.Y);
                        }
                        else
                        {
                            movable.NewPosition = new Vector2(gameObject.Bounds.Right, movable.NewPosition.Y);
                        }

                        continue;
                    }
                }

                if (new Rectangle((int)movable.Position.X, (int)movable.NewPosition.Y, 48, 48).Intersects(gameObject.Bounds))
                {
                    if (movable.Direction.Y > 0)
                    {
                        movable.NewPosition = new Vector2(movable.NewPosition.X, gameObject.Bounds.Top - movable.Bounds.Height);
                        movable.IsOnGround = true;
                    }
                    else
                    {
                        movable.NewPosition = new Vector2(movable.NewPosition.X, gameObject.Bounds.Bottom);
                        movable.Direction = new Vector2(movable.Direction.X, 0);
                    }
                }
            }

            movable.Position = movable.NewPosition;
        }
 
    }
}
