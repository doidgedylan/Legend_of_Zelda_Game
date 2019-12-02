using Legend_of_zelda_game.CollectableSprites;
using Legend_of_zelda_game.LinkSprites;
using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game
{

    public class LinkWinState : ILinkState
    {
        private Link link;
        ICollectable collectable;
        private LinkPickUpItemSprite2 linkPickUpItemSprite2;

        public LinkWinState(Link link)
        {
            this.link = link;
            this.collectable = new CollectableTriforceSprite(link.spriteBatch, link.Location);
            this.collectable.LocationRect = new Rectangle((int)link.Location.X + collectable.LocationRect.Width/4, (int)link.Location.Y - collectable.LocationRect.Height, collectable.LocationRect.Width, collectable.LocationRect.Height);
            linkPickUpItemSprite2 = new LinkPickUpItemSprite2(link);
        }

        public void Update()
        {
            linkPickUpItemSprite2.Draw();
            collectable.Update();
        }
    }
}
