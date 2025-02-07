﻿using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game
{
    public class BackgroundSpriteBottom : IBackground
    {
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        private Vector2 location;

        public BackgroundSpriteBottom(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            this.spriteSheet = Texture2DStorage.GetBackgroundSpriteSheetBottom();
            this.location = location;
        }
        public void Draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)location.X + 2400, (int)location.Y + 1650);
            spriteBatch.Draw(spriteSheet, destinationRectangle, Color.White);
        }

        public void ScrollIn(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void ScrollOut(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
