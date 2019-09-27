﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_ocho
{
    public class LinkWoodSwordDownSprite4 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordDownSprite4(Link link)
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
            int xPos = 52;
            int yPos = 47;
            int width = 16;
            int height = 18;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}