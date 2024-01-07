using gamedevproject.GameStateClasses;
using gamedevproject.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace gamedevproject.ScreenClasses
{
    internal class Screen: IScreen
    {
        private GameStateManager _gsman;
        private GameState _gameState;
        private SpriteBatch _spriteBatch;

        private Texture2D _startScreenTexture;
        private Texture2D _startScreenText;
    }
}
