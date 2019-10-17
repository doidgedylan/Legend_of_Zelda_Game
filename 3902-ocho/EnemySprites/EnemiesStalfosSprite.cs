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


        public EnemiesStalfosSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetStalfosSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void Update()
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

            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
