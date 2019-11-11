﻿using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class UnpauseCommand : ICommand
    {
        private Game1 game;

        public UnpauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.StateManager.FromItemSelectTransition();
        }

    }
}