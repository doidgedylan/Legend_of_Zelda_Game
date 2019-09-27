using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    class EnemiesWallmasterSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 11;
        private int width = 16;
        private int height = 16;
        private int scale = 3;
        private int destinationXPos = 700;
        private int destinationYPos = 200;

        public EnemiesWallmasterSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 393;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 410;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 393;
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
