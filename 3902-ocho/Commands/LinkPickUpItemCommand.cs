using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class LinkPickUpItemCommand : ICommand
    {
        private Link link;

        public LinkPickUpItemCommand(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            if (link.state.GetType().Name != "LinkMoveUpState")
            {
                link.state = new LinkPickUpItemState(link);
            }
        }
    }
}
