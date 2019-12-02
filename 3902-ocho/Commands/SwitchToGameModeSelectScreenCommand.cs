using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using System;

namespace Legend_of_zelda_game.Commands
{
    public class SwitchToGameModeSelectScreenCommand : ICommand
    {
        private Game1 game;
        private int roomNum;
        public SwitchToGameModeSelectScreenCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.StateManager.SetGameModeSelectScreenState();
        }
    }
}
