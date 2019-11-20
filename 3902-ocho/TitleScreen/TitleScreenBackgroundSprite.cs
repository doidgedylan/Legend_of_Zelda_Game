using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game.TitleScreen
{
    class TitleScreenBackgroundSprite : ITitleScreen
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private int xPos = 1;
        private int yPos = 11;
        private int width = 256;
        private int height = 224;

        public TitleScreenBackgroundSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetTitleScreenSpriteSheet();
            this.spriteBatch = spriteBatch;
            Location = new Vector2(0, 0);
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            Rectangle LocationRect = new Rectangle((int)Location.X, (int)Location.Y, 800, 716);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
