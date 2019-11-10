using Legend_of_zelda_game.Interfaces;
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

        private void DrawAtPoint(int x, int y)
        {
            Rectangle sourceRectangle = new Rectangle((int)location.X, (int)location.Y, 802, 550);
            Rectangle destinationRectangle = new Rectangle(x, y, 802, 550);
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void ScrollIn(Direction direction)
        {
            int x, y;
            switch (direction)
            {
                case Direction.Up:
                    x = 0;
                    y = 718;
                    while (y > 168)
                    {
                        DrawAtPoint(x, y);
                        y--;
                    }
                    return;
                case Direction.Down:
                    x = 0;
                    y = -382;
                    while (y < 168)
                    {
                        DrawAtPoint(x, y);
                        y++;
                    }
                    return;
                case Direction.Left:
                    x = 802;
                    y = 168;
                    while (x > 0)
                    {
                        DrawAtPoint(x, y);
                        x--;
                    }
                    return;
                case Direction.Right:
                    x = -802;
                    y = 168;
                    while (x < 0)
                    {
                        DrawAtPoint(x, y);
                        x++;
                    }
                    return;
                default:
                    // do nothing
                    return;
            }
        }
        public void ScrollOut(Direction direction)
        {
            int x, y;
            switch (direction)
            {
                case Direction.Up:
                    x = 0;
                    y = 168;
                    while (y > -382)
                    {
                        DrawAtPoint(x, y);
                        y--;
                    }
                    return;
                case Direction.Down:
                    x = 0;
                    y = 168;
                    while (y < 718)
                    {
                        DrawAtPoint(x, y);
                        y++;
                    }
                    return;
                case Direction.Left:
                    x = 0;
                    y = 168;
                    while (x > -802)
                    {
                        DrawAtPoint(x, y);
                        x--;
                    }
                    return;
                case Direction.Right:
                    x = 0;
                    y = 168;
                    while (x < 802)
                    {
                        DrawAtPoint(x, y);
                        x++;
                    }
                    return;
                default:
                    // do nothing
                    return;
            }
        }
    }
}
