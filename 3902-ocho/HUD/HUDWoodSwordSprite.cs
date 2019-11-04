using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class HUDWoodSwordSprite : ISprite
    {
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        public Rectangle LocationRect { get; set; }
        private int xPos = 555;
        private int yPos = 137;
        private int width = 8;
        private int height = 16;
        private int scale = 3;

        public HUDWoodSwordSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.spriteBatch = spriteBatch;
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
