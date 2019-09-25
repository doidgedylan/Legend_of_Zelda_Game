using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3902_ocho
{
    class HurtLinkCommand : ICommand
    {
        private HealthStateMachine healthStateMachine;
        public event EventHandler CanExecuteChanged;

        public HurtLinkCommand(HealthStateMachine healthStateMachine)
        {
            this.healthStateMachine = healthStateMachine;
        }
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            healthStateMachine.BeHurt();
        }
    }
}
