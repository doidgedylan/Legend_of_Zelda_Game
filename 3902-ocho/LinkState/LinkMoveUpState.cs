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
            link.Location = Vector2.Subtract(link.Location, new Vector2(0, link.speed));

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
            if (link.Location.Y <= endPosition)
                link.Location = new Vector2(link.Location.X, 434);
        }
    }
}
