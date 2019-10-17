using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkWoodSwordRightSprite3 : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;
        private int width;
        private int height;

        public LinkWoodSwordRightSprite3(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
            width = 23;
            height = 16;
        }

        public void Draw()
        {
            link.locationRect = new Rectangle((int)link.location.X, (int)link.location.Y, width * link.scale, height * link.scale);
            link.spriteBatch.Draw(spriteSheet, link.locationRect, GetSourceRectangle(), link.tint);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 46;
            int yPos = 77;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
