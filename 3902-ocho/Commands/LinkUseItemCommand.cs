using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    class LinkUseItemCommand : ICommand
    {
        private Link link;

        public LinkUseItemCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name == "LinkMoveDownState" || link.state.GetType().Name == "LinkIdleDownState")
            {
                link.state = new LinkUseItemDownState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveUpState" || link.state.GetType().Name == "LinkIdleUpState")
            {
                link.state = new LinkUseItemUpState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveLeftState" || link.state.GetType().Name == "LinkIdleLeftState")
            {
                link.state = new LinkUseItemLeftState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveRightState" || link.state.GetType().Name == "LinkIdleRightState")
            {
                link.state = new LinkUseItemRightState(link);
            }
        }
    }
}
