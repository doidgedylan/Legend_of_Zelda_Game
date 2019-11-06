using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _3902_ocho.Door;

namespace Legend_of_zelda_game
{
    public class RoomSprite : IBackground
    {
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        private Vector2 location;

        public RoomSprite(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            this.spriteBatch = spriteBatch;
            this.spriteSheet = spriteSheet;
            this.location = location;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle((int)location.X, (int)location.Y, 802, 550);
            Rectangle destinationRectangle = new Rectangle(0, 168, 802, 550);
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void ScrollIn(Direction direction)
        {

        }
        public void ScrollOut(Direction direction)
        {

        }
    }
}
