﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.LinkSprites
{
    public class LinkWoodSwordUpSprite3 : ILinkSprite
    {
        private Link link;
        Texture2D spriteSheet;
        private int width;
        private int height;

        public LinkWoodSwordUpSprite3(Link link)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.link = link;
            width = 16;
            height = 26;
        }

        public void Draw()
        {
            link.locationRect = new Rectangle((int)link.Location.X, (int)link.Location.Y - (height - 16) * link.scale, width * link.scale, height * link.scale);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            link.spriteBatch.Draw(spriteSheet, link.locationRect, GetSourceRectangle(), link.tint, 0, new Vector2(0, 0), s, 0f);
        }

        public Rectangle GetSourceRectangle()
        {
            int xPos = 35;
            int yPos = 98;

            return new Rectangle(xPos, yPos, width, height);
        }
    }
}
