using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;

namespace _3902_ocho.Blocks
{
    public class Block : IBlock
    {
        private Vector2 location;
        public Block(Vector2 location)
        {
            this.location = location;
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
