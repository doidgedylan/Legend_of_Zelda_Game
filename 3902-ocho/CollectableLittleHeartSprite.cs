using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class CollectableLittleHeartSprite : ICollectable
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        private int currentFrame = 0;
        private int totalFrames = 30;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 7;
        private int height = 8;

        public CollectableLittleHeartSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 0;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 8;
            } else
            {
                xPos = 16;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 0;
            }

            this.Draw();
        }

        public void Draw()
        {
            destinationRectangle = new Rectangle(330, 260, width * 3, height * 3);
            sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
