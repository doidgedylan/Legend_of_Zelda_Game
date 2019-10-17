using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkMoveDownSprite2 : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;
        private int width;
        private int height;

        public LinkMoveDownSprite2(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
            width = 16;
            height = 16;
        }

        public void Draw()
        {
            link.locationRect = new Rectangle((int)link.location.X, (int)link.location.Y, width * link.scale, height * link.scale);
            link.spriteBatch.Draw(spriteSheet, link.locationRect, GetSourceRectangle(), link.tint);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 18;
            int yPos = 11;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
