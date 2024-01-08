using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.GameStateClasses
{
    internal class LevelState : GameState
    {
        public Level Level { get; set; }

        public LevelState(Game game)
        {
            this.Game = game;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            Level.Draw(_spriteBatch);
        }

        public override void Enter(GameStates state)
        {
            Game.Content.Unload();
            switch (state)
            {
                case GameStates.LEVEL1:
                    using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 1)))
                        Level = new Level(Game.Services, fileStream);
                    Level.Background = Game.Content.Load<Texture2D>("Backgrounds/city3");
                    break;
                case GameStates.LEVEL2:
                    using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 2)))
                        Level = new Level(Game.Services, fileStream);
                    Level.Background = Game.Content.Load<Texture2D>("Backgrounds/forest");
                    break;
                case GameStates.LEVEL3:
                    using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 3)))
                        Level = new Level(Game.Services, fileStream);
                    Level.Background = Game.Content.Load<Texture2D>("Backgrounds/clouds2");
                    break;
                default:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            Level.Update(gameTime);
        }
    }
}
