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

        public int maxFrames;

        public int frameY;

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

        public void GetFrames(int widthSprite, int heightSprite)
        {
            counter = 0;
            frames.Clear();

            for (int x = 0; x < widthSprite * maxFrames; x += widthSprite)
            {
                frames.Add(new AnimationFrame(new Rectangle(x, heightSprite * frameY, widthSprite, heightSprite)));
            }
        }
    }
}
