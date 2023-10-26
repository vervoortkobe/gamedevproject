using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.AnimationClasses
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;

        private double timer;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            timer += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;

            if (timer >= 1d / fps)
            {
                counter++;
                timer = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTexture(int width,int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int frameWidth = width / numberOfWidthSprites;
            int frameHeight = height / numberOfHeightSprites;

            for (int y = 0; y <= height - frameHeight; y += frameHeight)
            {
                for (int x = 0; x <= width - frameWidth; x += frameWidth)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, frameWidth, frameHeight)));
                }
            }
        }
    }
}
