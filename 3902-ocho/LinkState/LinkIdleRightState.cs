

namespace Legend_of_zelda_game
{

    public class LinkIdleRightState : ILinkState
    {
        private Link link;

        public LinkIdleRightState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkMoveRightSprite1 linkMoveRightSprite1 = new LinkMoveRightSprite1(link);
            LinkMoveRightSprite2 linkMoveRightSprite2 = new LinkMoveRightSprite2(link);

            if (link.currentFrame <= 10)
            {
                linkMoveRightSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveRightSprite2.Draw();
            }
        }
    }
}
