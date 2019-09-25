using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class LinkStopCommand : ICommand
    {
        private Link link;
        public event EventHandler CanExecuteChanged;

        public LinkStopCommand(Link link)
        {
            this.link = link;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (link.state.GetType().Name == "LinkMoveDownState")
            {
                link.state = new LinkIdleDownState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveUpState")
            {
                link.state = new LinkIdleUpState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveLeftState")
            {
                link.state = new LinkIdleLeftState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveRightState")
            {
                link.state = new LinkIdleRightState(link);
            }
        }
    }
}
