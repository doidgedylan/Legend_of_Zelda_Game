using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    class AnimatedSpriteCommand : ICommand
    {
        private Game1 game;
        private ISprite animatedSprite;

        public AnimatedSpriteCommand(Game1 game, ISprite animatedSprite)
        {
            this.game = game;
            this.animatedSprite = animatedSprite;
        }
        public void Execute()
        {
            this.game.CurrentSprite = this.animatedSprite;
        }
    }
}
