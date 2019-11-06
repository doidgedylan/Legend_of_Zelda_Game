using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesKeeseSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 10;
        private int xPos = 0;
        private int yPos = 14;
        private int width = 16;
        private int height = 10;
        private int scale = 3;

        private int xPosition = -1;
        private int yPosition = -1;


        public EnemiesKeeseSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            this.Draw(spriteBatch);
            this.ApplyAnimation();
            this.ApplyMovement();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 5)
            {
                xPos = 183;
            }
            else if (currentFrame > 5 && currentFrame <= 10)
            {
                xPos = 200;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 183;
            }
        }

        private void ApplyMovement()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            if (xPosition == -1 && yPosition == -1)
            {
                destinationRectangle.X -= 1;
            }
            if (xPosition == -1 && yPosition == 1)
            {
                destinationRectangle.Y += 1;
            }
            if (xPosition == 1 && yPosition == -1)
            {
                destinationRectangle.Y -= 1;
            }
            if (xPosition == 1 && yPosition == 1)
            {
                destinationRectangle.X += 1;
            }
            if (destinationRectangle.Y >= (480) || destinationRectangle.Y <= 0)
            {
                yPosition *= -1;
            }
            if (destinationRectangle.X >= (800) || destinationRectangle.X <= 0)
            {
                xPosition *= -1;
            }
            LocationRect = destinationRectangle;
        }
    }
}
