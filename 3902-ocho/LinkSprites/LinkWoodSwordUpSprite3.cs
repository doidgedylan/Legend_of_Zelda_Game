﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_ocho
{
    public class LinkWoodSwordUpSprite3 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkWoodSwordUpSprite3(Link link)
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
            int xPos = 35;
            int yPos = 98;
            int width = 16;
            int height = 26;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}