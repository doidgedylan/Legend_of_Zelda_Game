using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class LinkPickUpItemCommand : ICommand
    {
        private Link link;
        public event EventHandler CanExecuteChanged;


        public LinkPickUpItemCommand(Link link)
        {
            this.link = link;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (link.state.GetType().Name != "LinkMoveUpState")
            {
                link.state = new LinkPickUpItemState(link);
            }
        }
    }
}
