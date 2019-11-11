using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.CollectableSprites
{
    public class CollectableLittleHeartSprite : ICollectable
    {
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
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
            LocationRect = new Rectangle((int)this.location.X, (int)this.location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            this.Draw(spriteBatch);
            this.ApplyAnimation();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
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
