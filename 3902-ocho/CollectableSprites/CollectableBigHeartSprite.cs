﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.CollectableSprites
{
    public class CollectableBigHeartSprite : ICollectable
    {
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        Texture2D spriteSheet;
        private int xPos = 25;
        private int yPos = 1;
        private int width = 13;
        private int height = 13;
        private int scale = 3;

        public CollectableBigHeartSprite(SpriteBatch spriteBatch, Vector2 location)
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
