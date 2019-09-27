using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, Z, X, C, E, N, Q, R, RightClick, LeftClick, NoButtonsPressed
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
