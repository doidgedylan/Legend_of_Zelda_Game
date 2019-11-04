using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;


namespace Legend_of_zelda_game.Blocks
{
    public class HorizontalWall : IBlock
    {
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 1;
        public int width = 800;
        public int height = 100;
        public HorizontalWall(Vector2 location)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width*scale, height*scale);
        }
        public void Update()
        {
            // do nothing
        }
    }
}
