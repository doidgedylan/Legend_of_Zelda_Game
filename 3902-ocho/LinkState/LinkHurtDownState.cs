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
            if (currentFrame <= 15 && link.Location.Y >= endPosition)
            {
                link.Location = Vector2.Subtract(link.Location, new Vector2(0, link.hurtSpeed));
            }
            else if (link.Location.X <= endPosition)
            {
                link.Location = new Vector2(link.Location.X, 0);
            }


            link.tint = link.hurtColors[currentFrame / 5];
            linkHurtDownSprite.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleDownState(link);
                link.tint = Color.White;
            }
        }
    }
}
