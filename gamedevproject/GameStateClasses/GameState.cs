using gamedevproject.Interfaces;

namespace gamedevproject.GameStateClasses
{
    public class GameState : IGameState
    {
        public GameStates GameStateValue { get; set; }
        public bool Paused { get; set; }
    }
}
