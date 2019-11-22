using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.Blocks
{
    public class Door : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 2;
        public int width = 25;
        public int height = 25;
        public Direction direction { get; }
        public int destinationRoomNumber { get; }

        public enum Direction { Left, Right, Up, Down }
        public Door(Vector2 location, int destinationRoomNumber, Direction direction)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.direction = direction;
            this.destinationRoomNumber = destinationRoomNumber;
        }

        public void Update()
        {
            // does nothing
        }
    }
}
