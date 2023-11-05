using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.States
{
    internal class IdleState : State
    {
        public IdleState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.animation.maxFrames = 10;
            player.animation.frameY = 0;
            player.animation.GetFrames(48, 48);
        }

        public override void HandleInput(Keys input)
        {
            if (input == Keys.Up)
            {
                player.StateManager.SetState(PlayerStates.JUMPING);
            }
            if (input == Keys.Left || input == Keys.Right)
            {
                player.StateManager.SetState(PlayerStates.RUNNING);
            }
        }
    }
}
