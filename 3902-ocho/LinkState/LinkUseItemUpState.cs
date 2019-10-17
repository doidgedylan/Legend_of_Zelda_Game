using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkUseItemUpState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkUseItemUpState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkUseItemUpSprite1 linkUseItemUpSprite1 = new LinkUseItemUpSprite1(link);
            
            currentFrame++;
            linkUseItemUpSprite1.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleUpState(link);
            }
        }
    }
}
