

namespace Legend_of_zelda_game
{

    public class LinkWoodSwordLeftState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkWoodSwordLeftState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkWoodSwordLeftSprite1 linkWoodSwordLeftSprite1 = new LinkWoodSwordLeftSprite1(link);
            LinkWoodSwordLeftSprite2 linkWoodSwordLeftSprite2 = new LinkWoodSwordLeftSprite2(link);
            LinkWoodSwordLeftSprite3 linkWoodSwordLeftSprite3 = new LinkWoodSwordLeftSprite3(link);
            LinkWoodSwordLeftSprite4 linkWoodSwordLeftSprite4 = new LinkWoodSwordLeftSprite4(link);

            currentFrame++;

            if (currentFrame <= 5)
            {
                linkWoodSwordLeftSprite1.Draw();
            }
            else if (currentFrame > 5 && currentFrame <= 10)
            {
                linkWoodSwordLeftSprite2.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 15)
            {
                linkWoodSwordLeftSprite3.Draw();
            }
            else if (currentFrame > 15 && currentFrame <= 20)
            {
                linkWoodSwordLeftSprite4.Draw();
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }
}
