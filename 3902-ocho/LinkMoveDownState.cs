using Microsoft.Xna.Framework;
using System;

namespace _3902_ocho
{

    public class LinkMoveDownState : ILinkState
    {
        private Link link;
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        int currentFrame;
        int totalFrames;
        int xPos;
        int yPos;
        int endPosition;

        public LinkMoveDownState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
            xPos = 400;
            yPos = 0;
            endPosition = 400;
        }

        public void Update()
        {
            LinkDownIdleSprite linkDownIdleSprite = new LinkDownIdleSprite();
            LinkDownRunSprite linkDownRunSprite = new LinkDownRunSprite();

            currentFrame++;
            yPos = yPos + 2;

            if (currentFrame <= 10)
            {
                sourceRectangle = linkDownIdleSprite.GetSourceRectangle();
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                sourceRectangle = linkDownRunSprite.GetSourceRectangle();
            }

            destinationRectangle = new Rectangle(xPos, yPos, 16 * 3, 16 * 3);

            link.Draw(sourceRectangle, destinationRectangle);

            if (currentFrame == totalFrames)
                currentFrame = 0;
            if (yPos == endPosition)
                yPos = 0;
        }
    }
}
