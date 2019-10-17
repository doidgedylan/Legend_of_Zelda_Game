using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesGoriyaSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
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
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
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

            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
