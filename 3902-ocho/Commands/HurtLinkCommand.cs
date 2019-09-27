using Legend_of_zelda_game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
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
