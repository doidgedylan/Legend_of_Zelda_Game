using _3902_ocho.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class LinkMoveRightCommand : ICommand
    {
        private Link link;


        public LinkMoveRightCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name != "LinkMoveRightState")
            {
                link.state = new LinkMoveRightState(link);
            }
        }
    }
}
