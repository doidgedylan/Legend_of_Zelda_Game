using Legend_of_zelda_game.CollectableSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class HUDMapSprite : IHUD
    {
        public Link link;
        private ISet<ICollectable> collectableSet;
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 8;
        private int height = 8;
        public int scale = 3;

        public HUDMapSprite(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            Rectangle originalDestinationRectangle = destinationRectangle;
            collectableSet = link.LinkItems;
            sourceRectangle = GetTopMapSourceRectangle();
            foreach (ICollectable collectable in collectableSet)
            {
                if (collectable is CollectableMapSprite)
                {
                    sourceRectangle = GetTopMapSourceRectangle();
                    Draw();
                    destinationRectangle.X -= width * scale;
                    destinationRectangle.Y += height * scale;
                    Draw();
                    destinationRectangle.X += 4 * (width * scale);
                    Draw();
                    sourceRectangle = GetBottomMapSourceRectangle();
                    destinationRectangle.Y -= height * scale;
                    Draw();
                    destinationRectangle.X += width * scale;
                    Draw();
                    destinationRectangle.X -= 4 * (width * scale);
                    destinationRectangle.Y += 2 * (height * scale);
                    Draw();
                    destinationRectangle.X += 2 * (width * scale);
                    Draw();
                    sourceRectangle = GetTopAndBottomMapSourceRectangle();
                    destinationRectangle.X -= width * scale;
                    Draw();
                    destinationRectangle.X += width * scale;
                    destinationRectangle.Y -= height * scale;
                    Draw();
                    destinationRectangle.X -= 2 * (width * scale);
                    Draw();
                    destinationRectangle.X += width * scale;
                    Draw();
                    destinationRectangle.Y -= height * scale;
                    Draw();
                }
            }
            destinationRectangle = originalDestinationRectangle;
        }

        public void Draw()
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetTopMapSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(663, 108, width, height);
            return rectangle;
        }

        public Rectangle GetBottomMapSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(672, 108, width, height);
            return rectangle;
        }

        public Rectangle GetTopAndBottomMapSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(681, 108, width, height);
            return rectangle;
        }
    }
}
