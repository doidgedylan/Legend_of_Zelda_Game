using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class CollectableLittleHeartSprite : ICollectable
    {
        SpriteBatch spriteBatch;
        private Vector2 location;
        Texture2D spriteSheet;
        private int currentFrame = 0;
        private int totalFrames = 30;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 7;
        private int height = 8;
        private int scale = 3;

        public CollectableLittleHeartSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
        }

        public void Update()
        {
            this.Draw(spriteBatch, location);
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
