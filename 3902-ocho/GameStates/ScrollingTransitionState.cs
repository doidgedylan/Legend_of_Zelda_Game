using _3902_ocho.Interfaces;
using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902_ocho.Door;

namespace _3902_ocho.GameStates
{
    public enum TransitionType { TO_ROOM, TO_ITEMSELECT }
    public class ScrollingTransitionState : IGameState
    {
        private IBackground originalBackground;
        private IBackground destinationBackground;
        private Direction direction;
        public ScrollingTransitionState(IBackground originalBackground, IBackground destinationBackground, Direction direction)
        {
            this.originalBackground = originalBackground;
            this.destinationBackground = destinationBackground;
            this.direction = direction;
        }
        public void Update()
        {
            // stop the game, do the scrolling stuff
            switch (direction)
            {
                case Direction.Up:
                    // scroll up
                    originalBackground.ScrollOut(Direction.Up);
                    destinationBackground.ScrollIn(Direction.Up);
                    return;
                case Direction.Down:
                    // scroll down
                    return;
                case Direction.Left:
                    // scroll left
                    return;
                case Direction.Right:
                    // scroll right
                    return;
                default:
                    // do nothing;
                    return;
            }
        }
    }
}
