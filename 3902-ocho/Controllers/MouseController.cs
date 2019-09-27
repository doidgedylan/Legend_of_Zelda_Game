using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Legend_of_zelda_game
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
                buttonMappings[Buttons.RightClick].Execute();
            }
            else if(CursorIsInBounds(CurrentState, WindowSize[0], WindowSize[1]) && (CurrentState.LeftButton == ButtonState.Pressed))
            {
                buttonMappings[Buttons.LeftClick].Execute();
            }
        }
    }
}
