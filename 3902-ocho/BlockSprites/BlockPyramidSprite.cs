﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    public class BlockPyramidSprite : IBlock
    {
        Texture2D spriteSheet;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 18;
        private int height = 18;
        private int scale = 2;

        public BlockPyramidSprite()
        {
            spriteSheet = Texture2DStorage.GetBlockSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
