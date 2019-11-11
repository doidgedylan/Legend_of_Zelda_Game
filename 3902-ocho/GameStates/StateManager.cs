using Legend_of_zelda_game;
using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Legend_of_zelda_game.Blocks.Door;

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
        private Link link;
        private SpriteBatch spriteBatch;

        public StateManager(Game1 game, SpriteBatch spriteBatch, SpriteFont font, Link link)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;
            this.link = link;
            this.gameplayState = new GameplayState(game, link);
            this.pauseState = new PauseState(game, spriteBatch, font);
            this.gameOverState = new GameOverState(game, spriteBatch, font);
            this.winningState = new WinningState(game, spriteBatch, font);
            this.itemSelectState = new ItemSelectState(game, spriteBatch, font);
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

        public void RoomTransition(Door door)
        {
            int originalRoomNumber = game.CurrentRoom.RoomNumber;
            int destinationRoomNumber = door.destinationRoomNumber;
            ScrollingTransitionToRoom(game.Rooms[originalRoomNumber].Background, game.Rooms[destinationRoomNumber].Background, door);
            SetLinkLocation(door.direction);
        }

        public void ToItemSelectTransition()
        {
            int originalRoomNumber = game.CurrentRoom.RoomNumber;
            game.CurrentState = new ScrollingTransitionState(game.Rooms[originalRoomNumber].Background, game.ItemSelectRoom.Background, Direction.Up);
            game.CurrentState.Update();
            SetItemSelectState();
        }

        public void FromItemSelectTransition()
        {
            int originalRoomNumber = game.CurrentRoom.RoomNumber;
            game.CurrentState = new ScrollingTransitionState(game.ItemSelectRoom.Background, game.Rooms[originalRoomNumber].Background, Direction.Down);
            game.CurrentState.Update();
            SetGameplayState();
        }

        private void SetLinkLocation(Direction direction)
        {
            int x = 0, y = 0;
            switch (direction)
            {
                case Direction.Up:
                    x = 375;
                    y = 550;
                    break;
                case Direction.Down:
                    x = 375;
                    y = 300;
                    break;
                case Direction.Left:
                    x = 650;
                    y = 418;
                    break;
                case Direction.Right:
                    x = 105;
                    y = 418;
                    break;
                default:
                    // do nothing
                    break;
            }
            Vector2 location = new Vector2(x, y);
            link.Location = location;
        }

        private void ScrollingTransitionToRoom(IBackground originalBackground, IBackground destinationBackground, Door door)
        {
            game.CurrentState = new ScrollingTransitionState(originalBackground, destinationBackground, door.direction);
            game.CurrentState.Update();
            game.SelectRoom(door.destinationRoomNumber);
            SetGameplayState();
        }
    }
}