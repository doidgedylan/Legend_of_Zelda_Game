using _3902_ocho.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class HurtLinkCommand : ICommand
    {
        private HealthStateMachine healthStateMachine;

        public HurtLinkCommand(HealthStateMachine healthStateMachine)
        {
            this.healthStateMachine = healthStateMachine;
        }

        public void Execute()
        {
            healthStateMachine.BeHurt();
        }
    }
}
