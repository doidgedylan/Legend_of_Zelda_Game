﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_ocho
{
    public class LinkMoveRightSprite2 : ISprite
    {
        private Link link;
        Texture2D spriteSheet;

        public LinkMoveRightSprite2(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
        }

        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)link.Location.X, (int)link.Location.Y, 16 * 3, 16 * 3);
            link.spriteBatch.Begin();
            link.spriteBatch.Draw(spriteSheet, destinationRectangle, GetSourceRectangle(), Color.White);
            link.spriteBatch.End();
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 52;
            int yPos = 11;
            int width = 16;
            int height = 16;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}