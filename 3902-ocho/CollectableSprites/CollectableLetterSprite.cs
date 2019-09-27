using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class CollectableLetterSprite : ICollectable
    {
        Texture2D spriteSheet;
        private int xPos = 88;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;
        private int scale = 3;

        public CollectableLetterSprite()
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
