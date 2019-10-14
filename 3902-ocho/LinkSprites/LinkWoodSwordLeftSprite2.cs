﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkWoodSwordLeftSprite2 : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordLeftSprite2(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle sourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = new Rectangle((int)link.location.X - (sourceRectangle.Width - 16) * 3, (int)link.location.Y, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, GetSourceRectangle(), Color.White, 0, new Vector2(0, 0), s, 0f);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 18;
            int yPos = 77;
            int width = 27;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
