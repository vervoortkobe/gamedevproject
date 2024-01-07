using gamedevproject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.GameStateClasses
{
    public class GameState : IGameState
    {
        public GameStates GameStateValue { get; set; }
    }
}
