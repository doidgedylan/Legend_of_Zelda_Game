using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;
using System.IO;

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
            string path = Directory.GetCurrentDirectory() + "\\The Legend of Zelda Cartoon Sound Effects\\The Legend of Zelda Cartoon Sound Effects Enemy Zapped.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();

            
        }

        public void Update()
        {

            LinkHurtRightSprite linkHurtRightSprite = new LinkHurtRightSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.Location.X >= endPosition)
            {
                link.Location = Vector2.Subtract(link.Location, new Vector2(link.hurtSpeed, 0));

            }
            else if (link.Location.X <= endPosition)
            {
                link.Location = new Vector2(0, link.Location.Y);
            }

            link.tint = link.hurtColors[currentFrame / 5];
            linkHurtRightSprite.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleRightState(link);
                link.tint = Color.White;
            }
            
        }
    }
}
