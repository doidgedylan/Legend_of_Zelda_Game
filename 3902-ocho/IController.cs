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
        D0, D1, D2, D3, D4, RightClick, Quad1LeftClick, Quad2LeftClick, Quad3LeftClick, Quad4LeftClick
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();

    }
}
