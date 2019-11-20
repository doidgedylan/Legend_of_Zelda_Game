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
    class TitleScreenWaterFallFoamSprite : ITitleScreen
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private int xPos = 776;
        private int yPos = 28;
        private int width = 32;
        private int height = 16;
        private int currentFrame = 0;
        private int totalFrames = 100;

        public TitleScreenWaterFallFoamSprite(SpriteBatch spriteBatch)
        {
            spriteSheet = Texture2DStorage.GetTitleScreenSpriteSheet();
            this.spriteBatch = spriteBatch;
            Location = new Vector2(250, 552);
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 776;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 809;
            }
            else if (currentFrame > 20 && currentFrame <= 30)
            {
                xPos = 842;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            Draw();
            location = Vector2.Add(Location, new Vector2(0, 4));
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            Rectangle LocationRect = new Rectangle((int)Location.X, (int)Location.Y, 100, 50);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
