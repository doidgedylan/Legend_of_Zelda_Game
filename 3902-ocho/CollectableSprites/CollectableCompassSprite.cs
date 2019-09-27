using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class CollectableCompassSprite : ICollectable
    {
        Texture2D spriteSheet;
        private int xPos = 258;
        private int yPos = 1;
        private int width = 11;
        private int height = 12;
        private int scale = 3;

        public CollectableCompassSprite()
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
