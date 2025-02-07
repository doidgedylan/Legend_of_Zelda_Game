﻿using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class LinkWoodSwordCommand : ICommand
    {
        private Link link;

        public LinkWoodSwordCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
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
