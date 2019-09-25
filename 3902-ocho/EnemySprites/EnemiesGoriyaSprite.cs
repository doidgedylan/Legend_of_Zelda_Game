﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class EnemiesGoriyaSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        private int currentFrame = 0;
        private int totalFrames = 16;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 14;
        private int height = 16;
        private int scale = 3;
        private int destinationXPos = 500;
        private int destinationYPos = 100;

        public EnemiesGoriyaSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetGoriyaSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 8)
            {
                yPos = 60;
            }
            else if (currentFrame > 8 && currentFrame <= 16)
            {
                yPos = 90;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                yPos = 60;
            }

            this.Draw();
        }

        public void Draw()
        {
            destinationRectangle = new Rectangle(destinationXPos, destinationYPos, width * scale, height * scale);
            sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}