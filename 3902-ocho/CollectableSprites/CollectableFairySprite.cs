using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho
{
    public class CollectableFairySprite : ICollectable
    {
        Texture2D spriteSheet;
        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 40;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;
        private int scale = 3;
        private int horizontalMovement = 0;
        private int veriticalMovement = 0;

        public CollectableFairySprite()
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

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        private void ApplyAnimation()
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
        }
    }
}
