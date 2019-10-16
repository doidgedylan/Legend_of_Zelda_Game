using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkHurtRightState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkHurtRightState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 30;
            endPosition = 0;
        }

        public void Update()
        {
            LinkHurtRightSprite linkHurtRightSprite = new LinkHurtRightSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.location.X >= endPosition)
            {
                link.location = Vector2.Subtract(link.location, new Vector2(5, 0));
            }
            else if (link.location.X >= endPosition)
            {
                link.location = Vector2.Add(link.location, new Vector2(5, 0));
            }
            else
            {
                link.location = new Vector2(0, link.location.Y);
            }

            link.tint = link.hurtColors[currentFrame / 5];

            if (currentFrame == totalFrames)
                currentFrame = 0;

            linkHurtRightSprite.Draw();
            link.tint = Color.White;
        }
    }
}
