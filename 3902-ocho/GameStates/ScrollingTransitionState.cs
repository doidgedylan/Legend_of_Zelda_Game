using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game.GameStates
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
            originalBackground.ScrollOut(direction);
            destinationBackground.ScrollIn(direction);
        }
    }
}
