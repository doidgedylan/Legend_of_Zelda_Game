using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkWoodSwordLeftSprite4 : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;
        private int width;
        private int height;

        public LinkWoodSwordLeftSprite4(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
            width = 19;
            height = 16;
        }

        public void Draw()
        {
            link.locationRect = new Rectangle((int)link.location.X - (width - 16) * link.scale, (int)link.location.Y, width * link.scale, height * link.scale);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            link.spriteBatch.Draw(spriteSheet, link.locationRect, GetSourceRectangle(), link.tint, 0, new Vector2(0, 0), s, 0f);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 70;
            int yPos = 77;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
