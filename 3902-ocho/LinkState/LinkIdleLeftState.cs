using Microsoft.Xna.Framework;
using System;

namespace Legend_of_zelda_game
{

    public class LinkIdleLeftState : ILinkState
    {
        private Link link;

        public LinkIdleLeftState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkMoveLeftSprite1 linkMoveLeftSprite1 = new LinkMoveLeftSprite1(link);
            LinkMoveLeftSprite2 linkMoveLeftSprite2 = new LinkMoveLeftSprite2(link);

            if (link.currentFrame <= 10)
            {
                linkMoveLeftSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveLeftSprite2.Draw();
            }
        }
    }
}
