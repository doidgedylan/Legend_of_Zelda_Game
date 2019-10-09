using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;

namespace _3902_ocho.Blocks
{
    public class WaterBlock : IBlock
    {
        private Vector2 location;
        public WaterBlock(Vector2 location)
        {
            this.location = location;
        }
        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
