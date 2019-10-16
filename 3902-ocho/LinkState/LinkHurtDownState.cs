using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkHurtDownState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkHurtDownState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 30;
            endPosition = 0;
        }

        public void Update()
        {
            LinkHurtDownSprite linkHurtDownSprite = new LinkHurtDownSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.location.Y >= endPosition)
            {
                link.location = Vector2.Subtract(link.location, new Vector2(0, 5));
            }
            else if (link.location.Y >= endPosition)
            {
                link.location = Vector2.Add(link.location, new Vector2(0, 5));
            }
            else
            {
                link.location = new Vector2(link.location.X, 0);
            }

            link.tint = link.hurtColors[currentFrame / 5];

            if (currentFrame == totalFrames)
                currentFrame = 0;

            linkHurtDownSprite.Draw();
            link.tint = Color.White;
        }
    }
}
