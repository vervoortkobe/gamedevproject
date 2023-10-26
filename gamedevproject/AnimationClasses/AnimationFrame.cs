using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
