using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework.Input;
using System;

namespace gamedevproject.States
{
    internal class RunningState : State
    {
        public RunningState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.animation.maxFrames = 8;
            player.animation.frameY = 3;
            player.animation.GetFrames(48, 48);
        }

        public override void HandleInput(Keys input)
        {
            if (input == Keys.Space || !player.IsOnGround)
            {
                player.StateManager.SetState(PlayerStates.JUMPING);
            }
            if(input == Keys.None)
            {
                player.StateManager.SetState(PlayerStates.IDLE);
            }
        }
    }
}
