using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class HUDItemBSprite : IHUD
    {
        public Link link;
        private Texture2D ItemSpriteSheet;
        private Texture2D PortalSpriteSheet;
        private Texture2D currentSpriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 8;
        private int height = 16;
        private int scale = 3;

        public HUDItemBSprite(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.ItemSpriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.PortalSpriteSheet = Texture2DStorage.GetPortalSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            currentSpriteSheet = ItemSpriteSheet;
            string currentItem = link.currentItem;
            if (currentItem.Equals("bomb"))
            {
                sourceRectangle = GetBombSourceRectangle();
            }
            else if (currentItem.Equals("arrow"))
            {
                sourceRectangle = GetArrowSourceRectangle();
            }
            else if (currentItem.Equals("bow"))
            {
                sourceRectangle = GetBowSourceRectangle();
            }
            else if (currentItem.Equals("portals"))
            {
                currentSpriteSheet = PortalSpriteSheet;
                sourceRectangle = GetPortalSourceRectangle();
            }
            else if (currentItem.Equals("boomerang"))
            {
                sourceRectangle = GetBoomerangSourceRectangle();
            }
            Draw();
        }

        public void Draw()
        {
            spriteBatch.Draw(currentSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetBowSourceRectangle()
        {
            width = 8;
            height = 16;
            Rectangle rectangle = new Rectangle(144, 0, width, height);
            return rectangle;
        }

        public Rectangle GetPortalSourceRectangle()
        {
            width = 81;
            height = 155;
            Rectangle rectangle = new Rectangle(162, 0, width, height);
            return rectangle;
        }

        public Rectangle GetArrowSourceRectangle()
        {
            width = 5;
            height = 16;
            Rectangle rectangle = new Rectangle(154, 0, width, height);
            return rectangle;
        }

        public Rectangle GetBombSourceRectangle()
        {
            width = 8;
            height = 16;
            Rectangle rectangle = new Rectangle(136, 0, width, height);
            return rectangle;
        }

        public Rectangle GetBoomerangSourceRectangle()
        {
            width = 5;
            height = 8;
            Rectangle rectangle = new Rectangle(129, 3, width, height);
            return rectangle;
        }
    }
}
