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


        public EnemiesKeeseSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
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

            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
