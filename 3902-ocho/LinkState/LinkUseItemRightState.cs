using Microsoft.Xna.Framework;
using System.Timers;

namespace Legend_of_zelda_game
{

    public class LinkUseItemRightState : ILinkState
    {
        private Link link;

        public LinkUseItemRightState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkUseItemRightSprite1 linkUseItemRightSprite1 = new LinkUseItemRightSprite1(link);
            linkUseItemRightSprite1.Draw();
        }
    }
}
