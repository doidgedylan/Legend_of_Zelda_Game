using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    public class SampleRoom1Sprite : IBackground
    {
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        private Vector2 location;

        public SampleRoom1Sprite(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            this.spriteSheet = Texture2DStorage.GetSampleRoom1SpriteSheet();
            this.location = location;
        }
        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)location.X + 800, (int)location.Y + 550);
            spriteBatch.Draw(spriteSheet, destinationRectangle, Color.White);
        }
    }
}
