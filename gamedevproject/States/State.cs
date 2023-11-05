using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework.Input;

namespace gamedevproject.States
{
    abstract internal class State
    {
        internal Player player;

        public State(Player player)
        {
            this.player = player;           
        }

        public abstract void Enter();

        public abstract void HandleInput(Keys input);
    }
}
