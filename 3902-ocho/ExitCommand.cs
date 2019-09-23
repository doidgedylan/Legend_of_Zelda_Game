using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class ExitCommand : ICommand
    {
        private Game1 game;
        public event EventHandler CanExecuteChanged;

        public ExitCommand(Game1 game)
        {
           this.game = game;
        }
        public bool CanExecute(object parameter)
        {
            // exit should always be able to execute
            return true;
        }

        public void Execute(object parameter)
        {
            this.game.Exit();
        }

    }
}
