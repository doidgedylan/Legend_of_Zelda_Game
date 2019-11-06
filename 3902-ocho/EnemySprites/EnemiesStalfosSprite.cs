using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesStalfosSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 8;
        private int width = 16;
        private int height = 16;
        private int scale = 3;

        private int xPosition = -1;


        public EnemiesStalfosSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetStalfosSpriteSheet();
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

            if (currentFrame <= 10)
            {
                xPos = 7;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 29;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 7;
            }

        }

        private void ApplyMovement()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            if (xPosition == -1)
            {
                destinationRectangle.X -= 1;
            }
            if (xPosition == 1)
            {
                destinationRectangle.X += 1;
            }

            if (destinationRectangle.X >= (800) || destinationRectangle.X <= 0)
            {
                xPosition *= -1;
            }
            LocationRect = destinationRectangle;
        }
    }
}
