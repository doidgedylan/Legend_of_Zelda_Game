﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkUseItemDownSprite1 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkUseItemDownSprite1(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y, 16 * 3, 16 * 3);
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, GetSourceRectangle(), Color.White);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 107;
            int yPos = 11;
            int width = 16;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
