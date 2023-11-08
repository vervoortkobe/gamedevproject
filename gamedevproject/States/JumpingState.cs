using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.States
{
    internal class JumpingState : State
    {
        public JumpingState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            player.animation.maxFrames = 3;
            player.animation.frameY = 1;
            player.animation.GetFrames(48, 48);
        }

        public override void HandleInput(Keys input)
        {
            if (player.OnGround())
            {
                player.StateManager.SetState(PlayerStates.IDLE);
            }
        }
    }
}
