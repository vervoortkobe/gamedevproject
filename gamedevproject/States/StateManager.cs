using gamedevproject.PlayerClasses;
using System.Collections.Generic;

namespace gamedevproject.States
{
    enum PlayerStates { IDLE, LANDING, JUMPING, RUNNING }

    internal class StateManager
    {
        public List<State>States { get; set; }

        public State CurrentState { get; set; }

        public Player Player { get; set; }

        public StateManager(Player player)
        {
            this.Player = player;
            States = new List<State>{
               new IdleState(this.Player),
               new LandingState(this.Player),
               new JumpingState(this.Player),
               new RunningState(this.Player)
            };
            CurrentState = States[0];
            CurrentState.Enter();
        }

        public void SetState(PlayerStates state)
        {
            CurrentState = States[(int)state];
            CurrentState.Enter();
        }
    }
}
