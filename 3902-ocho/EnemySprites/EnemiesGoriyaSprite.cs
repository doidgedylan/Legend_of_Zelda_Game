using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesGoriyaSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 16;
        private int xPos = 0;
        private int yPos = 0;
        private int width = 14;
        private int height = 16;
        private int scale = 3;


        public EnemiesGoriyaSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetGoriyaSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 8)
            {
                yPos = 60;
            }
            else if (currentFrame > 8 && currentFrame <= 16)
            {
                yPos = 90;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                yPos = 60;
            }

            this.Draw(spriteBatch, location);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
