using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using System;

namespace Legend_of_zelda_game.Commands
{
    public class SwitchToGamePlayCommand : ICommand
    {
        private Game1 game;
        private int roomNum;
        public SwitchToGamePlayCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.StateManager.SetGameplayState();
        }
    }
}
