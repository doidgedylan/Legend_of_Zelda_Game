using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkIdleUpState : ILinkState
    {
        private Link link;

        public LinkIdleUpState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkMoveUpSprite1 linkMoveUpSprite1 = new LinkMoveUpSprite1(link);
            LinkMoveUpSprite2 linkMoveUpSprite2 = new LinkMoveUpSprite2(link);

            if (link.currentFrame <= 10)
            {
                linkMoveUpSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveUpSprite2.Draw();
            }
        }
    }
}
