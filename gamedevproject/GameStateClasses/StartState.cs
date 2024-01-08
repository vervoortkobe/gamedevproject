using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.GameStateClasses
{
    internal class StartState : GameState
    {
        public StartState(Game game)
        {
            this.Game = game;
            this.State = GameStates.STARTSCREEN;
        }
        public override void Enter()
        {
            Game.Content.Unload();
            this.Texture = Game.Content.Load<Texture2D>("Backgrounds/startscreen2");
            this.Text = Game.Content.Load<Texture2D>("Backgrounds/start2");
        }
        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.659f, 0.63f), SpriteEffects.None, 0f);
            _spriteBatch.Draw(Text, new Vector2(5, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(0.27f, 0.25f), SpriteEffects.None, 0f);
        }
        
    }
}
