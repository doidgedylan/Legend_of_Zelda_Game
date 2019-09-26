using Microsoft.Xna.Framework;
using System.Timers;

namespace _3902_ocho
{

    public class LinkUseItemDownState : ILinkState
    {
        private Link link;

        public LinkUseItemDownState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkUseItemDownSprite1 linkUseItemDownSprite1 = new LinkUseItemDownSprite1(link);
            linkUseItemDownSprite1.Draw();
        }
    }
}
