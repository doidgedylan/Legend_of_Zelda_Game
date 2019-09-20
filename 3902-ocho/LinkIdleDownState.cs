using Microsoft.Xna.Framework;
using System;

namespace _3902_ocho
{

    public class LinkIdleDownState : ILinkState
    {
        private Link link;

        public LinkIdleDownState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkMoveDownSprite1 linkMoveDownSprite1 = new LinkMoveDownSprite1(link);
            LinkMoveDownSprite2 linkMoveDownSprite2 = new LinkMoveDownSprite2(link);

            if (link.currentFrame <= 10)
            {
                linkMoveDownSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveDownSprite2.Draw();
            }
        }
    }
}
