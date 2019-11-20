using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class DoNothingCommand : ICommand
    {

        public DoNothingCommand()
        {
        }

        public void Execute()
        {
            //Do Nothing
        }
    }
}
