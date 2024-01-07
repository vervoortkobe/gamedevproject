using gamedevproject.GameStateClasses;

namespace gamedevproject.Interfaces
{
    internal interface IGameState
    {
        public GameStates GameStateValue { get; set; }
    }
}
