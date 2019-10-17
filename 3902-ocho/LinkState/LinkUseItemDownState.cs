using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkUseItemDownState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkUseItemDownState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;
        }

        public void Update()
        {
            LinkUseItemDownSprite1 linkUseItemDownSprite1 = new LinkUseItemDownSprite1(link);

            currentFrame++;
            linkUseItemDownSprite1.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleUpState(link);
            }
        }
    }
}
