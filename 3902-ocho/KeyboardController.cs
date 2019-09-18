﻿using Microsoft.Xna.Framework.Input;
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

            keyMappings.Add(Keys.D0, Buttons.D0);
            keyMappings.Add(Keys.D1, Buttons.D1);
            keyMappings.Add(Keys.D2, Buttons.D2);
            keyMappings.Add(Keys.D3, Buttons.D3);
            keyMappings.Add(Keys.D4, Buttons.D4);
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
        }
    }
}
