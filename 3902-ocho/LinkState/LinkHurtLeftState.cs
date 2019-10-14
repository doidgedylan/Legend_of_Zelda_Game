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
                link.location = Vector2.Add(link.location, new Vector2(5, 0));
            }
            else if (link.location.X <= endPosition)
            {
                link.location = Vector2.Subtract(link.location, new Vector2(5, 0));
            }
            else
            {
                link.location = new Vector2(750, link.location.Y);
            }

            if (currentFrame <= 5)
            {
                link.tint = Color.Green;
            }
            else if (currentFrame > 10 && currentFrame <= 15)
            {
                link.tint = Color.Gray;
            }
            else if (currentFrame > 15 && currentFrame <= 20)
            {
                link.tint = Color.Red;
            }
            else if (currentFrame > 20 && currentFrame <= 25)
            {
                link.tint = Color.Black;
            }
            else if (currentFrame > 25 && currentFrame <= 30)
            {
                link.tint = Color.Orange;
            }
            else if (currentFrame > 25 && currentFrame <= 30)
            {
                link.tint = Color.DarkRed;
            }
            else if (currentFrame > 25 && currentFrame <= 30)
            {
                link.tint = Color.Blue;
            }

            if (currentFrame == totalFrames)
                currentFrame = 0;

            linkHurtLeftSprite.Draw();
            link.tint = Color.White;
        }
    }
}
