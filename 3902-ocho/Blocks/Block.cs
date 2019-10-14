using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;

namespace _3902_ocho.Blocks
{
    public class Block : IBlock
    {
        private Vector2 location;
        public Rectangle Area { get; }
        public Block(Vector2 location)
        {
            this.location = location;
            this.Area = new Rectangle((int)location.X, (int)location.Y, 36, 36);
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
