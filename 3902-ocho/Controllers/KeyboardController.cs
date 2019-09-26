using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    public class KeyboardController : IController
    {
        private Dictionary<Buttons, ICommand> commandMappings;
        private Dictionary<Keys, Buttons> keyMappings;

        public KeyboardController()
        {
            commandMappings = new Dictionary<Buttons, ICommand>();
            keyMappings = new Dictionary<Keys, Buttons>();

            keyMappings.Add(Keys.D1, Buttons.D1);
            keyMappings.Add(Keys.D2, Buttons.D2);
            keyMappings.Add(Keys.D3, Buttons.D3);
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
            keyMappings.Add(Keys.V, Buttons.V);
            keyMappings.Add(Keys.E, Buttons.E);
            keyMappings.Add(Keys.N, Buttons.N);
            keyMappings.Add(Keys.Q, Buttons.Q);
            keyMappings.Add(Keys.R, Buttons.R);
            keyMappings.Add(Keys.T, Buttons.T);
            keyMappings.Add(Keys.Y, Buttons.Y);
            keyMappings.Add(Keys.None, Buttons.NoButtonsPressed);
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            commandMappings.Add(button, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (keyMappings.ContainsKey(key))
                {
                    commandMappings[keyMappings[key]].Execute(null);
                }
            }
            if (pressedKeys.Length == 0)
            {
                commandMappings[keyMappings[Keys.None]].Execute(null);
            }
        }
    }
}
