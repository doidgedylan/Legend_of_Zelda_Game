using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legend_of_zelda_game.Blocks;

namespace Legend_of_zelda_game
{
    public class BackgroundSpriteTopRight : IBackground
    {
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        private Vector2 location;

        public BackgroundSpriteTopRight(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            this.spriteSheet = Texture2DStorage.GetBackgroundSpriteSheetTopRight();
            this.location = location;
        }
        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)location.X + 2400, (int)location.Y + 1650);
            spriteBatch.Draw(spriteSheet, destinationRectangle, Color.White);
        }

        public void ScrollIn(Door.Direction direction)
        {
            throw new NotImplementedException();
        }

        public void ScrollOut(Door.Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
