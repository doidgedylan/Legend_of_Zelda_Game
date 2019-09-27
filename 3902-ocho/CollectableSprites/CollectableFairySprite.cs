using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class CollectableFairySprite : ICollectable
    {
        Texture2D spriteSheet;
        private Rectangle destinationRectangle;
        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 40;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;
        private int scale = 3;
        private int horizontalPosition = -1;
        private int verticalPosition = -1;

        public CollectableFairySprite(Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            this.ApplyAnimation();
            this.ApplyMovement();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
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

        private void ApplyMovement()
        {
            if (horizontalPosition == -1 && verticalPosition == -1)
            {
                destinationRectangle.Y -= 1;
                destinationRectangle.X -= 1;
            }
            if (horizontalPosition == -1 && verticalPosition == 1)
            {
                destinationRectangle.Y += 1;
                destinationRectangle.X -= 1;
            }
            if (horizontalPosition == 1 && verticalPosition == -1)
            {
                destinationRectangle.Y -= 1;
                destinationRectangle.X += 1;
            }
            if (horizontalPosition == 1 && verticalPosition == 1)
            {
                destinationRectangle.Y += 1;
                destinationRectangle.X += 1;
            }
            if (destinationRectangle.Y >= (480) || destinationRectangle.Y <= 0)
            {
                verticalPosition *= -1;
            }
            if (destinationRectangle.X >= (800) || destinationRectangle.X <= 0)
            {
                horizontalPosition *= -1;
            }
        }
    }
}
