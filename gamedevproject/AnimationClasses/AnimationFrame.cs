using Microsoft.Xna.Framework;

namespace gamedevproject.AnimationClasses
{
    internal class AnimationFrame
    {
        public Rectangle SourceRect { get; set; }

        public AnimationFrame(Rectangle rect)
        {
            SourceRect = rect;
        }
    }
}
