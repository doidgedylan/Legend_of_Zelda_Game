using Microsoft.Xna.Framework;
using System.Timers;

namespace _3902_ocho
{

    public class LinkWoodSwordDownState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkWoodSwordDownState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkWoodSwordDownSprite1 linkWoodSwordDownSprite1 = new LinkWoodSwordDownSprite1(link);
            LinkWoodSwordDownSprite2 linkWoodSwordDownSprite2 = new LinkWoodSwordDownSprite2(link);
            LinkWoodSwordDownSprite3 linkWoodSwordDownSprite3 = new LinkWoodSwordDownSprite3(link);
            LinkWoodSwordDownSprite4 linkWoodSwordDownSprite4 = new LinkWoodSwordDownSprite4(link);

            currentFrame++;

            if (currentFrame <= 5)
            {
                linkWoodSwordDownSprite1.Draw();
            }
            else if (currentFrame > 5 && link.currentFrame <= 10)
            {
                linkWoodSwordDownSprite2.Draw();
            }
            else if (currentFrame > 10 && link.currentFrame <= 15)
            {
                linkWoodSwordDownSprite3.Draw();
            }
            else if (currentFrame > 15 && link.currentFrame <= 20)
            {
                linkWoodSwordDownSprite4.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }
}
