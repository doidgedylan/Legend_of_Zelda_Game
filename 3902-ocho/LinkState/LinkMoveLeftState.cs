using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game
{

    public class LinkMoveLeftState : ILinkState
    {
        private Link link;
        int totalFrames;
        int endPosition;

        public LinkMoveLeftState(Link link)
        {
            this.link = link;
            totalFrames = 20;
            endPosition = 0;
        }

        public void Update()
        {
            LinkMoveLeftSprite1 linkMoveLeftSprite1 = new LinkMoveLeftSprite1(link);
            LinkMoveLeftSprite2 linkMoveLeftSprite2 = new LinkMoveLeftSprite2(link);

            link.currentFrame++;
            link.Location = Vector2.Subtract(link.Location, new Vector2(link.speed, 0));

            if (link.currentFrame <= 10)
            {
                linkMoveLeftSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveLeftSprite2.Draw();
            }

            if (link.currentFrame == totalFrames)
                link.currentFrame = 0;
            if (link.Location.X <= endPosition)
                link.Location = new Vector2(750, link.Location.Y);
        }
    }
}
