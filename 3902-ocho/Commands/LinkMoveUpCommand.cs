using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class LinkMoveUpCommand : ICommand
    {
        private Link link;
        public event EventHandler CanExecuteChanged;


        public LinkMoveUpCommand(Link link)
        {
            this.link = link;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (link.state.GetType().Name != "LinkMoveUpState")
            {
                link.state = new LinkMoveUpState(link);
            }
        }
    }
}
