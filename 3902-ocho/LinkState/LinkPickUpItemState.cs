using Legend_of_zelda_game.LinkSprites;
using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game
{

    public class LinkPickUpItemState : ILinkState
    {
        private Link link;
        ICollectable collectable;
        int currentFrame;
        int totalFrames;

        public LinkPickUpItemState(Link link, ICollectable collectable)
        {
            this.link = link;
            this.collectable = collectable;
            this.collectable.LocationRect = new Rectangle((int)link.Location.X, (int)link.Location.Y - collectable.LocationRect.Height, collectable.LocationRect.Width, collectable.LocationRect.Height);
            currentFrame = 0;
            totalFrames = 100;
        }

        public void Update()
        {
            LinkPickUpItemSprite1 linkPickUpItemSprite1 = new LinkPickUpItemSprite1(link);
            LinkPickUpItemSprite2 linkPickUpItemSprite2 = new LinkPickUpItemSprite2(link);

            currentFrame++;

            if (currentFrame <= 40)
            {
                linkPickUpItemSprite1.Draw();
            }
            else if (currentFrame > 40 && link.currentFrame <= 100)
            {
                linkPickUpItemSprite2.Draw();
            }
            collectable.Update();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleDownState(link);
            }
        }
    }
}
