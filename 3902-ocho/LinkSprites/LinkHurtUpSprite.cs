using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkHurtUpSprite : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkHurtUpSprite(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y, 16 * 3, 16 * 3);
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, GetSourceRectangle(), link.tint);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 69;
            int yPos = 11;
            int width = 16;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
