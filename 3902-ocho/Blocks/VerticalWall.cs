using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.Blocks
{
    public class VerticalWall : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 1;
        public int width = 100;
        public int height = 550;

        public VerticalWall(Vector2 location)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }
    }
}
