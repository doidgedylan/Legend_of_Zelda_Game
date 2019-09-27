using Legend_of_zelda_game.Interfaces;

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
