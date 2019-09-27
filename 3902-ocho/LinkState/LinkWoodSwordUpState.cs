using Microsoft.Xna.Framework;
using System.Timers;

namespace _3902_ocho
{

    public class LinkWoodSwordUpState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkWoodSwordUpState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkWoodSwordUpSprite1 linkWoodSwordUpSprite1 = new LinkWoodSwordUpSprite1(link);
            LinkWoodSwordUpSprite2 linkWoodSwordUpSprite2 = new LinkWoodSwordUpSprite2(link);
            LinkWoodSwordUpSprite3 linkWoodSwordUpSprite3 = new LinkWoodSwordUpSprite3(link);
            LinkWoodSwordUpSprite4 linkWoodSwordUpSprite4 = new LinkWoodSwordUpSprite4(link);

            currentFrame++;

            if (currentFrame <= 5)
            {
                linkWoodSwordUpSprite1.Draw();
            }
            else if (currentFrame > 5 && currentFrame <= 10)
            {
                linkWoodSwordUpSprite2.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 15)
            {
                linkWoodSwordUpSprite3.Draw();
            }
            else if (currentFrame > 15 && currentFrame <= 20)
            {
                linkWoodSwordUpSprite4.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }
}
