using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, E, Z, N, Q, R, X, M, D0, D1, D2, D3, D4, RightClick, LeftClick
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
