using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game
{

    public class LinkMoveDownState : ILinkState
    {
        private Link link;
        int totalFrames;
        int endPosition;

        public LinkMoveDownState(Link link)
        {
            this.link = link;
            totalFrames = 20;
            endPosition = 434;
        }

        public void Update()
        {
            LinkMoveDownSprite1 linkMoveDownSprite1 = new LinkMoveDownSprite1(link);
            LinkMoveDownSprite2 linkMoveDownSprite2 = new LinkMoveDownSprite2(link);

            link.currentFrame++;
            link.Location = Vector2.Add(link.Location, new Vector2(0, link.speed));

            if (link.currentFrame <= 10)
            {
                linkMoveDownSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveDownSprite2.Draw();
            }

            if (link.currentFrame == totalFrames)
                link.currentFrame = 0;
            if (link.Location.Y >= endPosition)
                link.Location = new Vector2(link.Location.X, 0);
        }
    }
}
