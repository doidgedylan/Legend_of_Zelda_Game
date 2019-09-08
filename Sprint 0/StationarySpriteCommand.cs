using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    class StationarySpriteCommand : ICommand
    {
        private Game1 game;
        private ISprite stationarySprite;

        public StationarySpriteCommand(Game1 game, ISprite stationarySprite)
        {
            this.game = game;
            this.stationarySprite = stationarySprite;
        }
        public void Execute()
        {
            this.game.CurrentSprite = this.stationarySprite;
        }
    }
}
