using Legend_of_zelda_game.CollectableSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class HUDMapLocation : IHUD
    {
        public Link link;
        private ISet<ICollectable> collectableSet;
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 3;
        private int height = 3;
        private int scale = 3;

        public HUDMapLocation(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            collectableSet = link.LinkItems;
            sourceRectangle = GetMapDotSourceRectangle();
            foreach (ICollectable collectable in collectableSet)
            {
                if (collectable is CollectableMapSprite)
                {
                    Draw();
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetMapDotSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(519, 126, width, height);
            return rectangle;
        }
    }
}
