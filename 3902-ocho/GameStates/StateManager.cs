using Legend_of_zelda_game;
using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.Interfaces;
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

        public StateManager(Game1 game, SpriteBatch spriteBatch, SpriteFont font, Link link)
        {
            this.game = game;
            this.gameplayState = new GameplayState(game, link);
            this.pauseState = new PauseState(game, spriteBatch, font);
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
            if (game.CurrentState == pauseState){
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

        public void ScrollingTransition(IBackground originalBackground, IBackground destinationBackground, TransitionType type, Door door)
        {
            game.CurrentState = new ScrollingTransitionState(originalBackground, destinationBackground, door.direction);
            game.CurrentState.Update();
            game.SelectRoom(door.destinationRoomNumber);
            if (type == TransitionType.TO_ROOM)
            {
                SetGameplayState();
            }
            else if (type == TransitionType.TO_ITEMSELECT)
            {
                SetItemSelectState();
            }
        }
    }
}