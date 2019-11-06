using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    public class EnemiesDragonSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 10;
        private int width = 24;
        private int height = 32;
        private int scale = 3;
        private int yPosition = -1;

        public EnemiesDragonSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetBossesSpriteSheet();
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
                xPos = 1;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 26;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
            }
        }

        private void ApplyMovement()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            if (yPosition == -1)
            {
                destinationRectangle.Y -= 1;
            }
            if (yPosition == 1)
            {
                destinationRectangle.Y += 1;
            }
            
            if (destinationRectangle.Y >= (480) || destinationRectangle.Y <= 0)
            {
                yPosition *= -1;
            }
            
            LocationRect = destinationRectangle;
        }


    }
}
