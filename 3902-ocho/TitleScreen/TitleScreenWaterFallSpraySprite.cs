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
    class TitleScreenWaterFallSpraySprite : ITitleScreen
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private int xPos = 846;
        private int yPos = 11;
        private int width = 32;
        private int height = 16;
        private int currentFrame = 0;
        private int totalFrames = 20;

        public TitleScreenWaterFallSpraySprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetTitleScreenSpriteSheet();
            this.spriteBatch = spriteBatch;
            Location = new Vector2(250, 514);
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 846;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 879;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            Rectangle LocationRect = new Rectangle((int)Location.X, (int)Location.Y, 100, 50);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
