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
    public class DrawBlocksCommand : ICommand
    {
        private SpriteBatch spriteBatch;
        private Game1 game;
        public event EventHandler CanExecuteChanged;

        public DrawBlocksCommand(Game1 game, SpriteBatch spriteBatch)
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
            this.game.pyramidBlock.Draw(spriteBatch, new Vector2(40, 190));
        }
    }
}
