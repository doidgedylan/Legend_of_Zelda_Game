using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;

namespace _3902_ocho.Blocks
{
    public class Block : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 2;
        public int width = 18;
        public int height = 18;

        public Block(Vector2 location)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void Update()
        {
            //Do nothing
        }
    }
}
