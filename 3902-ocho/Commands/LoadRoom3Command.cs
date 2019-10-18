using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;

namespace _3902_ocho.Commands
{
    public class LoadRoom3Command : ICommand
    {
        private Game1 game;
        public LoadRoom3Command(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.LoadRoomContent(3);
        }
    }
}
