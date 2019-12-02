using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Legend_of_zelda_game.Controllers
{
    public class MouseController : IController
    {
        private readonly int[] WindowSize = { 800, 480 };
        private Dictionary<Buttons, ICommand> buttonMappings;
        public MouseState previousState;
        public MouseState currentState;

        public MouseController()
        {
            previousState = Mouse.GetState();
            currentState = Mouse.GetState();
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
            UpdateStates();
            int MouseX = currentState.X;
            int MouseY = currentState.Y;
            if (CursorIsInBounds(currentState, WindowSize[0], WindowSize[1]) && (currentState.RightButton == ButtonState.Pressed))
            {
                buttonMappings[Buttons.RightClick].Execute();
            }
            else if(CursorIsInBounds(currentState, WindowSize[0], WindowSize[1]) && (currentState.LeftButton == ButtonState.Pressed))
            {
                buttonMappings[Buttons.LeftClick].Execute();
            }
        }

        public void UpdateStates()
        {
            previousState = currentState;
            currentState = Mouse.GetState();
        }
    }
}
