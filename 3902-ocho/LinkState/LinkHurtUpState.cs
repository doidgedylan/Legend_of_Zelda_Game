using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkHurtUpState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkHurtUpState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 30;
            endPosition = 400;
        }

        public void Update()
        {
            LinkHurtUpSprite linkHurtUpSprite = new LinkHurtUpSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.Location.Y <= endPosition)
            {
                link.Location = Vector2.Add(link.Location, new Vector2(0, 5));
            }
            else if (link.Location.Y <= endPosition)
            {
                link.Location = Vector2.Subtract(link.Location, new Vector2(0, 5));
            }
            else
            {
                link.Location = new Vector2(link.Location.X, 434);
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

            linkHurtUpSprite.Draw();
            link.tint = Color.White;
        }
    }
}
