using Legend_of_zelda_game.LinkSprites;
using System.IO;

namespace Legend_of_zelda_game
{

    public class LinkWoodSwordRightState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkWoodSwordRightState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 20;

            string path = Directory.GetCurrentDirectory() + "\\The Legend of Zelda Cartoon Sound Effects\\The Legend of Zelda Cartoon Sound Effects Sword Zap SFX.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();
        }

        public void Update()
        {
            LinkWoodSwordRightSprite1 linkWoodSwordRightSprite1 = new LinkWoodSwordRightSprite1(link);
            LinkWoodSwordRightSprite2 linkWoodSwordRightSprite2 = new LinkWoodSwordRightSprite2(link);
            LinkWoodSwordRightSprite3 linkWoodSwordRightSprite3 = new LinkWoodSwordRightSprite3(link);
            LinkWoodSwordRightSprite4 linkWoodSwordRightSprite4 = new LinkWoodSwordRightSprite4(link);

            currentFrame++;

            if (currentFrame <= 5)
            {
                linkWoodSwordRightSprite1.Draw();
            }
            else if (currentFrame > 5 && currentFrame <= 10)
            {
                linkWoodSwordRightSprite2.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 15)
            {
                linkWoodSwordRightSprite3.Draw();
            }
            else if (currentFrame > 15 && currentFrame <= 20)
            {
                linkWoodSwordRightSprite4.Draw();
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleRightState(link);
            }
        }
    }
}
