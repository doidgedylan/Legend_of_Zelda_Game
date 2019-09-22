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
        private int currentFrame = 0;
        private int totalFrames = 30;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 7;
        private int height = 8;
        private int scale = 3;

        public CollectableLittleHeartSprite()
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
        }

        public void Update()
        {
            this.ApplyAnimation();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 0;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 8;
            }
            else
            {
                xPos = 16;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 0;
            }
        }
    }
}
