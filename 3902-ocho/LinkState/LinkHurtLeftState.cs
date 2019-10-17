using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkHurtLeftState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkHurtLeftState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 30;
            endPosition = 750;
        }

        public void Update()
        {
            LinkHurtLeftSprite linkHurtLeftSprite = new LinkHurtLeftSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.location.X <= endPosition)
            {
                link.location = Vector2.Add(link.location, new Vector2(link.hurtSpeed, 0));
            }
            else if (link.location.X >= endPosition)
            { 
                link.location = new Vector2(750, link.location.Y);
            }

            link.tint = link.hurtColors[currentFrame / 5];

            linkHurtLeftSprite.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleLeftState(link);
                link.tint = Color.White;
            }
        }
    }
}
