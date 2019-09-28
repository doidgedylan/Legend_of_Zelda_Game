using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkUseItemDownState : ILinkState
    {
        private Link link;

        public LinkUseItemDownState(Link link)
        {
            this.link = link;
        }

        public void Update()
        {
            LinkUseItemDownSprite1 linkUseItemDownSprite1 = new LinkUseItemDownSprite1(link);
            linkUseItemDownSprite1.Draw();
        }
    }
}
