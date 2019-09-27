using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class LinkMoveLeftCommand : ICommand
    {
        private Link link;

        public LinkMoveLeftCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name != "LinkMoveLeftState")
            {
                link.state = new LinkMoveLeftState(link);
            }
        }
    }
}
