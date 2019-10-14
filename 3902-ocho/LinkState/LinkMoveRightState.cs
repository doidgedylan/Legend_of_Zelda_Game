using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkMoveRightState : ILinkState
    {
        private Link link;
        int totalFrames;
        int endPosition;

        public LinkMoveRightState(Link link)
        {
            this.link = link;
            totalFrames = 20;
            endPosition = 750;
        }

        public void Update()
        {
            LinkMoveRightSprite1 linkMoveRightSprite1 = new LinkMoveRightSprite1(link);
            LinkMoveRightSprite2 linkMoveRightSprite2 = new LinkMoveRightSprite2(link);

            link.currentFrame++;
            link.location = Vector2.Add(link.location, new Vector2(link.speed, 0));

            if (link.currentFrame <= 10)
            {
                linkMoveRightSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveRightSprite2.Draw();
            }

            if (link.currentFrame == totalFrames)
                link.currentFrame = 0;
            if (link.location.X >= endPosition)
                link.location = new Vector2(0, link.location.Y);
        }
    }
}
