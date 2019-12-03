using Legend_of_zelda_game.CollectableSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class HUDPauseMapSprite : IHUD
    {
        public Link link;
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 8;
        private int height = 8;
        public int scale = 3;

        public HUDPauseMapSprite(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            sourceRectangle = GetRoomOutlineSourceRectangle();
            Draw();
        }

        public void Draw()
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetRoomOutlineSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(654, 108, width, height);
            return rectangle;
        }
    }
}
