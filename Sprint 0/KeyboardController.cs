using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    // Adapted from http://web.cse.ohio-state.edu/~boggus.2/3902/slides/KeyboardController.cs
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyMappings;
        public KeyboardController()
        {
            keyMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            keyMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                keyMappings[key].Execute();
            }
        }
    }
}
