using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Legend_of_zelda_game.Controllers
{
    public class KeyboardController : IController
    {
        private Dictionary<Buttons, ICommand> commandMappings;
        private Dictionary<Keys, Buttons> keyMappings;
        public KeyboardState previousState;
        public KeyboardState currentState;

        public KeyboardController()
        {
            previousState = Keyboard.GetState();
            currentState = Keyboard.GetState();
            commandMappings = new Dictionary<Buttons, ICommand>();
            keyMappings = new Dictionary<Keys, Buttons>();

            keyMappings.Add(Keys.Enter, Buttons.Enter);
            keyMappings.Add(Keys.Up, Buttons.Up);
            keyMappings.Add(Keys.Down, Buttons.Down);
            keyMappings.Add(Keys.Left, Buttons.Left);
            keyMappings.Add(Keys.Right, Buttons.Right);
            keyMappings.Add(Keys.W, Buttons.W);
            keyMappings.Add(Keys.A, Buttons.A);
            keyMappings.Add(Keys.S, Buttons.S);
            keyMappings.Add(Keys.D, Buttons.D);
            keyMappings.Add(Keys.Z, Buttons.Z);
            keyMappings.Add(Keys.X, Buttons.X);
            keyMappings.Add(Keys.C, Buttons.C);
            keyMappings.Add(Keys.N, Buttons.N);
            keyMappings.Add(Keys.Q, Buttons.Q);
            keyMappings.Add(Keys.R, Buttons.R);
            keyMappings.Add(Keys.B, Buttons.B);
            keyMappings.Add(Keys.G, Buttons.G);
            keyMappings.Add(Keys.D1, Buttons.D1);
            keyMappings.Add(Keys.D2, Buttons.D2);
            keyMappings.Add(Keys.D3, Buttons.D3);
            keyMappings.Add(Keys.D4, Buttons.D4);
            keyMappings.Add(Keys.D5, Buttons.D5);
            keyMappings.Add(Keys.D6, Buttons.D6);
            keyMappings.Add(Keys.D7, Buttons.D7);
            keyMappings.Add(Keys.D8, Buttons.D8);
            keyMappings.Add(Keys.D9, Buttons.D9);
            keyMappings.Add(Keys.D0, Buttons.D0);
            keyMappings.Add(Keys.NumPad1, Buttons.NumPad1);
            keyMappings.Add(Keys.NumPad2, Buttons.NumPad2);
            keyMappings.Add(Keys.NumPad3, Buttons.NumPad3);
            keyMappings.Add(Keys.NumPad4, Buttons.NumPad4);
            keyMappings.Add(Keys.NumPad5, Buttons.NumPad5);
            keyMappings.Add(Keys.NumPad6, Buttons.NumPad6);
            keyMappings.Add(Keys.NumPad7, Buttons.NumPad7);
            keyMappings.Add(Keys.NumPad8, Buttons.NumPad8);
            keyMappings.Add(Keys.None, Buttons.NoButtonsPressed);
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            commandMappings.Add(button, command);
        }

        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
            Keys[] pressedKeys = currentState.GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (keyMappings.ContainsKey(key))
                {
                    commandMappings[keyMappings[key]].Execute();
                }
            }
            if (pressedKeys.Length == 0)
            {
                commandMappings[keyMappings[Keys.None]].Execute();
            }
        }
    }
}
