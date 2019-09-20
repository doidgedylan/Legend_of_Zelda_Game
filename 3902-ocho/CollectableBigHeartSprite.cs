using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class CollectableBigHeartSprite : ICollectable
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private int xPos = 25;
        private int yPos = 1;
        private int width = 13;
        private int height = 13;
        private int scale = 3;
        private int destinationXPos = 260;
        private int destinationYPos = 270;

        public CollectableBigHeartSprite(SpriteBatch spriteBatch)
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
