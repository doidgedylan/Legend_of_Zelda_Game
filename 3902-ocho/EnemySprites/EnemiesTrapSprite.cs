using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    class EnemiesTrapSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 59;
        private int width = 16;
        private int height = 16;
        private int scale = 3;
        private int destinationXPos = 600;
        private int destinationYPos = 200;

        public EnemiesTrapSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 164;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 164;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 164;
            }

            this.Draw();
        }

        public void Draw()
        {
            destinationRectangle = new Rectangle(destinationXPos, destinationYPos, width * scale, height * scale);
            sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
