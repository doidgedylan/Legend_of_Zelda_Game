using Legend_of_zelda_game.GameStates;
using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class SwitchHordeAndNormalModeCommand : ICommand
    {
        private GameModeSelectScreenState gameModeSelectScreenState;
        public SwitchHordeAndNormalModeCommand(GameModeSelectScreenState gameModeSelectScreenState)
        {
            this.gameModeSelectScreenState = gameModeSelectScreenState;
        }

        public void Execute()
        {
            gameModeSelectScreenState.SwitchNormalAndHordeMode();
        }
    }
}
