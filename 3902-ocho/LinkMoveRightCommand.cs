﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class LinkMoveRightCommand : ICommand
    {
        private Link link;
        public event EventHandler CanExecuteChanged;


        public LinkMoveRightCommand(Link link)
        {
            this.link = link;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (link.state.GetType().Name != "LinkMoveRightState")
            {
                link.state = new LinkMoveRightState(link);
            }
        }
    }
}
