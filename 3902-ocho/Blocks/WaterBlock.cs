using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.Blocks
{
    public class WaterBlock : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 2;
        public int width = 25;
        public int height = 25;
        public WaterBlock(Vector2 location)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width*scale, height*scale);
        }
    }
}
