using gamedevproject.PlayerClasses;
using Microsoft.Xna.Framework.Input;

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
            if (player.IsOnGround && input == Keys.None)
            {
                player.StateManager.SetState(PlayerStates.IDLE);
            }
            if(player.IsOnGround && (input == Keys.Left || input == Keys.Right))
            {
                player.StateManager.SetState(PlayerStates.RUNNING);
            }
        }
    }
}
