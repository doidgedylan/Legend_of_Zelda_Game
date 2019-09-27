using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class LinkStopCommand : ICommand
    {
        private Link link;

        public LinkStopCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name == "LinkMoveDownState")
            {
                link.state = new LinkIdleDownState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveUpState")
            {
                link.state = new LinkIdleUpState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveLeftState")
            {
                link.state = new LinkIdleLeftState(link);
            }
            else if (link.state.GetType().Name == "LinkMoveRightState")
            {
                link.state = new LinkIdleRightState(link);
            }
        }
    }
}
