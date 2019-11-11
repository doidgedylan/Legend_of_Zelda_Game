using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.CollectableSprites
{
    public class CollectableMultipleRupeeSprite : ICollectable
    {
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        Texture2D spriteSheet;
        private int xPos = 72;
        private int yPos = 16;
        private int width = 8;
        private int height = 16;
        private int scale = 3;

        public CollectableMultipleRupeeSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)this.location.X, (int)this.location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
