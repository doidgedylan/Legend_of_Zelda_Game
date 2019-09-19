using Microsoft.Xna.Framework;
using System;

namespace _3902_ocho
{

    public class LinkMoveLeftState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkMoveLeftState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
            endPosition = 0;
        }

        public void Update()
        {
            LinkMoveLeftSprite1 linkMoveLeftSprite1 = new LinkMoveLeftSprite1(link);
            LinkMoveLeftSprite2 linkMoveLeftSprite2 = new LinkMoveLeftSprite2(link);

            currentFrame++;
            link.Location = Vector2.Subtract(link.Location, new Vector2(link.speed, 0));

            if (currentFrame <= 10)
            {
                linkMoveLeftSprite1.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                linkMoveLeftSprite2.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
            if (link.Location.X <= endPosition)
                link.Location = new Vector2(750, link.Location.Y);
        }
    }
}
