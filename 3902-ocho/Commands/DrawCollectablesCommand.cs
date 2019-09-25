using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho.Commands
{
    public class DrawCollectablesCommand : ICommand
    {
        private SpriteBatch spriteBatch;
        private Game1 game;
        public event EventHandler CanExecuteChanged;

        public DrawCollectablesCommand(Game1 game, SpriteBatch spriteBatch)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.game.bomb.Draw(spriteBatch, new Vector2(80, 300));
            this.game.boomerang.Draw(spriteBatch, new Vector2(120, 300));
            this.game.bow.Draw(spriteBatch, new Vector2(160, 300));
            this.game.clock.Draw(spriteBatch, new Vector2(200, 300));
            this.game.compass.Draw(spriteBatch, new Vector2(240, 300));
            this.game.fairy.Draw(spriteBatch, new Vector2(280, 300));
            this.game.bigHeart.Draw(spriteBatch, new Vector2(320, 300));
            this.game.littleHeart.Draw(spriteBatch, new Vector2(360, 300));
            this.game.key.Draw(spriteBatch, new Vector2(400, 300));
            this.game.letter.Draw(spriteBatch, new Vector2(440, 300));
            this.game.singleRupee.Draw(spriteBatch, new Vector2(480, 300));
            this.game.multipleRupee.Draw(spriteBatch, new Vector2(520, 300));
            this.game.sword.Draw(spriteBatch, new Vector2(560, 300));
            this.game.triforce.Draw(spriteBatch, new Vector2(600, 300));
            this.game.arrow.Draw(spriteBatch, new Vector2(640, 300));
        }
    }
}
