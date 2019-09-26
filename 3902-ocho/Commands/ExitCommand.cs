using _3902_ocho.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class ExitCommand : ICommand
    {
        private Game1 game;

        public ExitCommand(Game1 game)
        {
           this.game = game;
        }

        public void Execute()
        {
            this.game.Exit();
        }

    }
}
