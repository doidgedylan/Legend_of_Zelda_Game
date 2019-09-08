using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    class ExitCommand : ICommand
    {
        private Game game;

        public ExitCommand(Game game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.Exit();
        }
    }
}
