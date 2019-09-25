using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class ResetCommand : ICommand
    {
        private Game1 game;
        public event EventHandler CanExecuteChanged;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            this.game.ReloadContent();
        }
    }
}
