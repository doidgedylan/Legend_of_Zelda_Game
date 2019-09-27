﻿using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    class LinkMoveDownCommand : ICommand
    {
        private Link link;


        public LinkMoveDownCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name != "LinkMoveDownState")
            {
                link.state = new LinkMoveDownState(link);
            }
        }
    }
}
