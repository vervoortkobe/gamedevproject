﻿using gamedevproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamedevproject.InputClasses
{
    class KeyboardReader : IInputReader
    {
        public Keys ReadInput()
        {
            var input = Keys.None;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                input = Keys.Left;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                input = Keys.Right;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                input = Keys.Up;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                input = Keys.Down;
            }
            if (state.IsKeyDown(Keys.Space)) 
            {
                input = Keys.Space;
            }

            return input;
        }
    }

}
