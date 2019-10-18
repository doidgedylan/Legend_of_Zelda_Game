using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using System;

namespace _3902_ocho.Commands
{
    public class LoadRoom1Command : ICommand
    {
        private Game1 game;
        public LoadRoom1Command(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.LoadRoomContent(1);
        }
    }
}
