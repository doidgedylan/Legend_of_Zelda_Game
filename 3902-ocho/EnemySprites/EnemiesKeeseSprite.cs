using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    class EnemiesKeeseSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        private int currentFrame = 0;
        private int totalFrames = 10;
        private int xPos = 0;
        private int yPos = 14;
        private int width = 16;
        private int height = 10;
        private int scale = 3;
        private int destinationXPos = 500;
        private int destinationYPos = 200;

        public EnemiesKeeseSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
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

            this.Draw();
        }

        public void Draw()
        {
            destinationRectangle = new Rectangle(destinationXPos, destinationYPos, width * scale, height * scale);
            sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
