using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game.Blocks
{
    public class LockedDoor : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private Vector2 location;
        public int scale = 2;
        public int width;
        public int height;
        private SpriteBatch spriteBatch;
        private Texture2D spriteSheet;
        public Direction direction { get; }

        public LockedDoor(Vector2 location, Direction direction, SpriteBatch spriteBatch)
        {
            this.location = location;
            this.direction = direction;
            this.spriteBatch = spriteBatch;
            this.spriteSheet = Texture2DStorage.GetLockedDoorsSpriteSheet();
        }

        public void Update()
        {
            Draw();
        }

        private void Draw()
        {
            Rectangle sourceRectangle;
            int x, y = 0;
            switch (direction)
            {
                case Direction.Up:
                    width = 50;
                    height = 30;
                    x = (int)location.X - 25;
                    y = (int)location.Y - 8;
                    sourceRectangle = new Rectangle(0, 20, width, height);
                    LocationRect = new Rectangle(x, y, width * scale, height * scale);
                    break;
                case Direction.Down:
                    width = 50;
                    height = 30;
                    x = (int)location.X - 25;
                    y = (int)location.Y - 4;
                    LocationRect = new Rectangle(x, y, width * scale, height * scale);
                    sourceRectangle = new Rectangle(0, 154, width, height);
                    break;
                case Direction.Left:
                    width = 30;
                    height = 50;
                    x = (int)location.X - 8;
                    y = (int)location.Y - 15;
                    LocationRect = new Rectangle(x, y, width * scale, height * scale);
                    sourceRectangle = new Rectangle(20, 51, width, height);
                    break;
                case Direction.Right:
                    width = 30;
                    height = 50;
                    x = (int)location.X - 2;
                    y = (int)location.Y - 15;
                    LocationRect = new Rectangle(x, y, width * scale, height * scale);
                    sourceRectangle = new Rectangle(0, 103, width, height);
                    break;
                default:
                    width = 50;
                    height = 30;
                    x = (int)location.X - 10;
                    y = (int)location.Y - 5;
                    sourceRectangle = new Rectangle(0, 0, width, height);
                    LocationRect = new Rectangle(x, y, width * scale, height * scale);
                    break;
            }
            spriteBatch.Draw(spriteSheet, locationRect, sourceRectangle, Color.White);
        }
    }
}
