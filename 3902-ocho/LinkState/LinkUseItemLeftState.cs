using Microsoft.Xna.Framework;
using System.Timers;

namespace Legend_of_zelda_game
{

    public class LinkUseItemLeftState : ILinkState
    {
        private Link link;

        public LinkUseItemLeftState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkUseItemLeftSprite1 linkUseItemLeftSprite1 = new LinkUseItemLeftSprite1(link);
            linkUseItemLeftSprite1.Draw();
        }
    }
}
