using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesGelSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 6;
        private int xPos = 0;
        private int yPos = 15;
        private int width = 8;
        private int height = 9;
        private int scale = 3;


        public EnemiesGelSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 3)
            {
                xPos = 1;
            }
            else if (currentFrame > 3 && currentFrame <= 6)
            {
                xPos = 10;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
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
