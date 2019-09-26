using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, Z, X, C, V, E, N, Q, R, D1, D2, D3, RightClick, LeftClick, NoButtonsPressed
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
