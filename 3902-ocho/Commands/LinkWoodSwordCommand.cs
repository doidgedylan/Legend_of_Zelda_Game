using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class LinkWoodSwordCommand : ICommand
    {
        private Link link;
        public event EventHandler CanExecuteChanged;

        public LinkWoodSwordCommand(Link link)
        {
            this.link = link;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (link.state.GetType().Name == "LinkMoveDownState" || link.state.GetType().Name == "LinkIdleDownState")
            {
                link.state = new LinkWoodSwordDownState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveUpState" || link.state.GetType().Name == "LinkIdleUpState")
            {
                link.state = new LinkWoodSwordUpState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveLeftState" || link.state.GetType().Name == "LinkIdleLeftState")
            {
                link.state = new LinkWoodSwordLeftState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveRightState" || link.state.GetType().Name == "LinkIdleRightState")
            {
                link.state = new LinkWoodSwordRightState(link);
            }
        }
    }
}
