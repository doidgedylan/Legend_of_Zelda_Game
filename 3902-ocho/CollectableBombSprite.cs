using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class CollectableBombSprite : ICollectable
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private int xPos = 136;
        private int yPos = 0;
        private int width = 8;
        private int height = 16;
        private int scale = 3;
        private int destinationXPos = 220;
        private int destinationYPos = 200;

        public CollectableBombSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
        }

        public void Update()
        {
            this.Draw();
        }

        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle(destinationXPos, destinationYPos, width * scale, height * scale);
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
