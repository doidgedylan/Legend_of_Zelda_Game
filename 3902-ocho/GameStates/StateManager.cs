using Legend_of_zelda_game;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.GameStates
{
    public class StateManager
    {
        private GameplayState gameplayState;
        private PauseState pauseState;
        private ItemSelectState itemSelectState;
        private GameOverState gameOverState;
        private WinningState winningState;
        private Game1 game;

        public StateManager(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.gameplayState = new GameplayState(spriteBatch);
            this.pauseState = new PauseState();
            this.gameOverState = new GameOverState(spriteBatch, font);
            this.winningState = new WinningState(spriteBatch, font);
            this.itemSelectState = new ItemSelectState();
        }

        public void SetGameplayState()
        {
            game.CurrentState = gameplayState;
        }

        public void SetPauseState()
        {
            if (game.CurrentState.Equals(pauseState)){
                SetGameplayState();
            }
            else
            {
                game.CurrentState = pauseState;
            }
        }

        public void SetItemSelectState()
        {
            game.CurrentState = itemSelectState;
        }

        public void SetWinningState()
        {
            game.CurrentState = winningState;
        }

        public void SetGameOverState()
        {
            game.CurrentState = gameOverState;
        }
    }
}
