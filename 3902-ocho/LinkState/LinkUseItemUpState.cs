using Microsoft.Xna.Framework;
using System.Timers;

namespace Legend_of_zelda_game
{

    public class LinkUseItemUpState : ILinkState
    {
        private Link link;

        public LinkUseItemUpState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkUseItemUpSprite1 linkUseItemUpSprite1 = new LinkUseItemUpSprite1(link);
            linkUseItemUpSprite1.Draw();
        }
    }
}
