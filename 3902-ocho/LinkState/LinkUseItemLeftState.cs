using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkUseItemLeftState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkUseItemLeftState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkUseItemLeftSprite1 linkUseItemLeftSprite1 = new LinkUseItemLeftSprite1(link);

            currentFrame++;
            linkUseItemLeftSprite1.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleLeftState(link);
            }
        }
    }
}
