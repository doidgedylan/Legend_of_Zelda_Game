using Legend_of_zelda_game.LinkSprites;
using System.IO;

namespace Legend_of_zelda_game
{

    public class LinkWoodSwordDownState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;

        public LinkWoodSwordDownState(Link link)
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
            LinkWoodSwordDownSprite1 linkWoodSwordDownSprite1 = new LinkWoodSwordDownSprite1(link);
            LinkWoodSwordDownSprite2 linkWoodSwordDownSprite2 = new LinkWoodSwordDownSprite2(link);
            LinkWoodSwordDownSprite3 linkWoodSwordDownSprite3 = new LinkWoodSwordDownSprite3(link);
            LinkWoodSwordDownSprite4 linkWoodSwordDownSprite4 = new LinkWoodSwordDownSprite4(link);

            currentFrame++;

            if (currentFrame <= 5)
            {
                linkWoodSwordDownSprite1.Draw();
            }
            else if (currentFrame > 5 && currentFrame <= 10)
            {
                linkWoodSwordDownSprite2.Draw();
            }
            else if (currentFrame > 10 && currentFrame <= 15)
            {
                linkWoodSwordDownSprite3.Draw();
            }
            else if (currentFrame > 15 && currentFrame <= 20)
            {
                linkWoodSwordDownSprite4.Draw();
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleDownState(link);
            }
        }
    }
}
