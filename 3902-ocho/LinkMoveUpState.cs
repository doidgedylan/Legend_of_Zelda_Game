using Microsoft.Xna.Framework;
using System;

namespace _3902_ocho
{

    public class LinkMoveUpState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkMoveUpState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
            endPosition = 0;
        }

        public void Update()
        {
            LinkMoveUpSprite1 linkMoveUpSprite1 = new LinkMoveUpSprite1(link);
            LinkMoveUpSprite2 linkMoveUpSprite2 = new LinkMoveUpSprite2(link);

            currentFrame++;
            link.Location = Vector2.Subtract(link.Location, new Vector2(0, link.speed));

            if (currentFrame <= 10)
            {
                linkMoveUpSprite1.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                linkMoveUpSprite2.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
            if (link.Location.Y <= endPosition)
                link.Location = new Vector2(link.Location.X, 400);
        }
    }
}
