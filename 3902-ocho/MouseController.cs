using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class MouseController : IController
    {
        private readonly int[] WindowSize = { 800, 480 };
        private Dictionary<Buttons, ICommand> buttonMappings;

        public MouseController()
        {
            buttonMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            buttonMappings.Add(button, command);
        }

        private bool CursorIsInBounds(MouseState currentState, int rightBound, int bottomBound)
        {
            return (currentState.X < rightBound && currentState.Y < bottomBound);
        }

        public void Update()
        {
            MouseState CurrentState = Mouse.GetState();
            int MouseX = CurrentState.X;
            int MouseY = CurrentState.Y;
            if (CursorIsInBounds(CurrentState, WindowSize[0], WindowSize[1]) && (CurrentState.RightButton == ButtonState.Pressed))
            {
                buttonMappings[Buttons.RightClick].Execute(null);
            }
            else if(CursorIsInBounds(CurrentState, WindowSize[0], WindowSize[1]) && (CurrentState.LeftButton == ButtonState.Pressed))
            {
                //buttonMappings[Buttons.LeftClick].Execute(null);
            }
        }
    }
}
