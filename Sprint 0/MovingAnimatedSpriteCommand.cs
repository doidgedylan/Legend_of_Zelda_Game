using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    class MovingAnimatedSpriteCommand : ICommand
    {
        private Game1 game;
        private ISprite movingAnimatedSprite;

        public MovingAnimatedSpriteCommand(Game1 game, ISprite movingAnimatedSprite)
        {
            this.game = game;
            this.movingAnimatedSprite = movingAnimatedSprite;
        }
        public void Execute()
        {
            this.game.CurrentSprite = this.movingAnimatedSprite;
        }
    }
}
