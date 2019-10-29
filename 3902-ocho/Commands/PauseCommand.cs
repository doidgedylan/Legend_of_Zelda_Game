using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class PauseCommand : ICommand
    {
        private Game1 game;

        public PauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.StateManager.SetPauseState();
        }

    }
}
