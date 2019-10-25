using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class OldManNPCSprite : ISprite
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private int currentFrame = 0;
        private int totalFrames = 30;
        private Vector2 location;
        private int xPos = 1;
        private int yPos = 11;
        private int width = 16;
        private int height = 16;
        private int scale = 3;

        public OldManNPCSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetOldManSpriteSheet();
            this.location = location;
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            this.ApplyAnimation();
            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 15)
            {
                xPos = 1;
            }
            else if (currentFrame > 15 && currentFrame <= 30)
            {
                xPos = 18;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
            }
        }
    }
}
