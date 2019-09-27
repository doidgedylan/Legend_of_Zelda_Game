﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Legend_of_zelda_game
{
    public class LinkWoodSwordRightSprite3 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordRightSprite3(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle sourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 46;
            int yPos = 77;
            int width = 23;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
