using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
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
