using Legend_of_zelda_game.CollectableSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class HUDCompassLocation : IHUD
    {
        public Link link;
        private ISet<ICollectable> collectableSet;
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle destinationRectangle;
        private int xPos = 537;
        private int yPos = 126;
        private int width = 3;
        private int height = 3;
        private int scale = 3;
        private int currentFrame = 0;
        private int totalFrames = 20;

        public HUDCompassLocation(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            collectableSet = link.LinkItems;
            foreach (ICollectable collectable in collectableSet)
            {
                collectableSet = link.LinkItems;
                if (collectable is CollectableCompassSprite)
                {
                    Draw();
                    ApplyAnimation();
                }
            }
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetCompassRedDotSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(537, 126, width, height);
            return rectangle;
        }

        public Rectangle GetCompassBlueDotSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(555, 126, width, height);
            return rectangle;
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 537;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 555;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 537;
            }
        }
    }
}
