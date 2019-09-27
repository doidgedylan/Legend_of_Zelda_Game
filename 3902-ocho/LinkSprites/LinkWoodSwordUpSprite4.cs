using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class LinkWoodSwordUpSprite4 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordUpSprite4(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle sourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y - (sourceRectangle.Height - 16) * 3, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 51;
            int yPos = 106;
            int width = 16;
            int height = 18;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
