using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    class MovingSpriteCommand : ICommand
    {
        private Game1 game;
        private ISprite movingSprite;

        public MovingSpriteCommand(Game1 game, ISprite movingSprite)
        {
            this.game = game;
            this.movingSprite = movingSprite;
        }
        public void Execute()
        {
            this.game.CurrentSprite = this.movingSprite;
        }
    }
}
