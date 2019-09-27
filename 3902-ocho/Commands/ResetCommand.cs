using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class ResetCommand : ICommand
    {
        private Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.ReloadContent();
        }
    }
}
