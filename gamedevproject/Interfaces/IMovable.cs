using gamedevproject.MovementClasses;
using gamedevproject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.Interfaces
{
    internal interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 NewPosition { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Rectangle Bounds { get; }
        public SpriteEffects SpriteEffects { get; set; }
        public IInputReader InputReader { get; set; }
        public MovementManager MovementManager { get; set; }
        public StateManager StateManager { get; set; }
        public bool IsOnGround { get; set; }

    }
}
