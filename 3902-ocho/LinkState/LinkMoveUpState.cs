using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkMoveUpState : ILinkState
    {
        private Link link;
        int totalFrames;
        int endPosition;

        public LinkMoveUpState(Link link)
        {
            this.link = link;
            totalFrames = 20;
            endPosition = 0;
        }

        public void Update()
        {
            LinkMoveUpSprite1 linkMoveUpSprite1 = new LinkMoveUpSprite1(link);
            LinkMoveUpSprite2 linkMoveUpSprite2 = new LinkMoveUpSprite2(link);

            link.currentFrame++;
            link.location = Vector2.Subtract(link.location, new Vector2(0, link.moveSpeed));

            if (link.currentFrame <= 10)
            {
                linkMoveUpSprite1.Draw();
            }
            else if (link.currentFrame > 10 && link.currentFrame <= 20)
            {
                linkMoveUpSprite2.Draw();
            }

            if (link.currentFrame == totalFrames)
                link.currentFrame = 0;
            if (link.location.Y <= endPosition)
                link.location = new Vector2(link.location.X, 434);
        }
    }
}
