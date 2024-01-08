using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.GameStateClasses
{
    public abstract class GameState
    {
        public Game Game { get; set; }
        public GameStates State { get; set; }
        internal Level Level { get; set; }
        public Texture2D Texture { get; set; }
        public Texture2D Text { get; set; }
        public abstract void Enter();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch _spriteBatch);

    }
}
