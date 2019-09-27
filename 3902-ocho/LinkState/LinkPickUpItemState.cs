using Microsoft.Xna.Framework;
using System.Timers;

namespace Legend_of_zelda_game
{

    public class LinkPickUpItemState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkPickUpItemState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 100;
        }

        public void Update()
        {
            LinkPickUpItemSprite1 linkPickUpItemSprite1 = new LinkPickUpItemSprite1(link);
            LinkPickUpItemSprite2 linkPickUpItemSprite2 = new LinkPickUpItemSprite2(link);

            currentFrame++;

            if (currentFrame <= 40)
            {
                linkPickUpItemSprite1.Draw();
            }
            else if (currentFrame > 40 && link.currentFrame <= 100)
            {
                linkPickUpItemSprite2.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }
}
