using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho.Commands
{
    public class LoadRoom2Command : ICommand
    {
        private Game1 game;
        public LoadRoom2Command(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.LoadRoomContent(2);
        }
    }
}
