using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    class LinkSwitchItemCommand : ICommand
    {
        private Link link;
        private string[] items = new string[4];
        private int i = 0;

        public LinkSwitchItemCommand(Link link)
        {
            this.link = link;
            items[0] = "arrow";
            items[1] = "bomb";
            items[2] = "boomerang";
            items[3] = "portals";
        }

        public void Execute()
        {
            link.currentItem = items[i];
            i++;
            if (i == 4)
            {
                i = 0;
            }
        }
    }
}
