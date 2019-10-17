using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkUseItemRightState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkUseItemRightState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkUseItemRightSprite1 linkUseItemRightSprite1 = new LinkUseItemRightSprite1(link);

            currentFrame++;
            linkUseItemRightSprite1.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleRightState(link);
            }
        }
    }
}
