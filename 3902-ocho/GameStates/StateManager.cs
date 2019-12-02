using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game.GameStates
{
    public class StateManager
    {
        private TitleScreenState titleScreenState;
        private GameModeSelectScreenState gameModeSelectScreenState;
        private GameplayState gameplayState;
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
            this.titleScreenState = new TitleScreenState(game);
            this.gameModeSelectScreenState = new GameModeSelectScreenState(game);
            this.gameplayState = new GameplayState(game, link);
            this.gameOverState = new GameOverState(game, spriteBatch, font);
            this.winningState = new WinningState(game, link, spriteBatch, font);
            this.itemSelectState = new ItemSelectState(game, link, spriteBatch, font);
        }

        public void SetTitleScreenState()
        {
            game.CurrentState = titleScreenState;
        }

        public void SetGameModeSelectScreenState()
        {
            game.CurrentState = gameModeSelectScreenState;
        }

        public void SetGameplayState()
        {
            game.CurrentState = gameplayState;
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

        public GameModeSelectScreenState GetGameModeSelectState()
        {
            return gameModeSelectScreenState;
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
            spriteBatch.Begin();
            int originalRoomNumber = game.CurrentRoom.RoomNumber;
            game.CurrentState = new ScrollingTransitionState(game.Rooms[originalRoomNumber].Background, game.ItemSelectRoom.Background, Direction.Up);
            game.CurrentState.Update();
            SetItemSelectState();
            spriteBatch.End();
        }

        public void FromItemSelectTransition()
        {
            spriteBatch.Begin();
            int originalRoomNumber = game.CurrentRoom.RoomNumber;
            game.CurrentState = new ScrollingTransitionState(game.ItemSelectRoom.Background, game.Rooms[originalRoomNumber].Background, Direction.Down);
            game.CurrentState.Update();
            SetGameplayState();
            spriteBatch.End();
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