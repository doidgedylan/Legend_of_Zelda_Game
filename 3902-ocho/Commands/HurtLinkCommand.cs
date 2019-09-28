using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class HurtLinkCommand : ICommand
    {
        private HealthStateMachine healthStateMachine;
        private Link link;

        public HurtLinkCommand(HealthStateMachine healthStateMachine, Link link)
        {
            this.healthStateMachine = healthStateMachine;
            this.link = link;
        }

        public void Execute()
        {
            healthStateMachine.BeHurt();
            if (link.state.GetType().Name == "LinkMoveDownState" || link.state.GetType().Name == "LinkIdleDownState")
            {
                link.state = new LinkHurtDownState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveUpState" || link.state.GetType().Name == "LinkIdleUpState")
            {
                link.state = new LinkHurtUpState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveLeftState" || link.state.GetType().Name == "LinkIdleLeftState")
            {
                link.state = new LinkHurtLeftState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveRightState" || link.state.GetType().Name == "LinkIdleRightState")
            {
                link.state = new LinkHurtRightState(link);
            }
        }
    }
}
