using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class CollectableCompassSprite : ICollectable
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private int xPos = 258;
        private int yPos = 1;
        private int width = 11;
        private int height = 12;
        private int scale = 3;
        private int destinationXPos = 200;
        private int destinationYPos = 260;

        public CollectableCompassSprite(SpriteBatch spriteBatch)
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
