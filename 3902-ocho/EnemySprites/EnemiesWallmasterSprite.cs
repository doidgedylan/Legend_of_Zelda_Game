﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesWallmasterSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 11;
        private int width = 16;
        private int height = 16;
        private int scale = 3;


        public EnemiesWallmasterSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 393;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 410;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 393;
            }

            this.Draw(spriteBatch, location);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
