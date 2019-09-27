using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Legend_of_zelda_game
{
    public class LinkWoodSwordLeftSprite1 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordLeftSprite1(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle sourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, GetSourceRectangle(), Color.White, 0, new Vector2(0, 0), s, 0f);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 1;
            int yPos = 77;
            int width = 16;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
