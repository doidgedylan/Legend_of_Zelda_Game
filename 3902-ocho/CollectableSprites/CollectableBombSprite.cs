using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho
{
    public class CollectableBombSprite : ICollectable
    {
        Texture2D spriteSheet;
        private int xPos = 136;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;
        private int scale = 3;

        public CollectableBombSprite()
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
