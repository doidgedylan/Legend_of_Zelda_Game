using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class CollectableFairySprite : ICollectable
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 40;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;

        public CollectableFairySprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 40;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 48;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 40;
            }

            this.Draw();
        }

        public void Draw()
        {
            destinationRectangle = new Rectangle(240, 260, width * 3, height * 3);
            sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
