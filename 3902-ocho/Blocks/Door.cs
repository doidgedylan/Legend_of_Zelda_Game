using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
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
        private bool locked;

        public enum Direction { Left, Right, Up, Down }
        public Door(Vector2 location, int destinationRoomNumber, Direction direction, bool locked)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.direction = direction;
            this.destinationRoomNumber = destinationRoomNumber;
            this.locked = locked;
        }

        public void Update()
        {
            // locks or unlocks door
            this.locked = !this.locked;
        }
    }
}
