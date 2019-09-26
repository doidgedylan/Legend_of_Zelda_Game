using _3902_ocho.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class LinkMoveUpCommand : ICommand
    {
        private Link link;


        public LinkMoveUpCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name != "LinkMoveUpState")
            {
                link.state = new LinkMoveUpState(link);
            }
        }
    }
}
