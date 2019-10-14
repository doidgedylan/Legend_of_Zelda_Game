using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho.Blocks
{
    public class VerticalWall : IBlock
    {
        private Vector2 location;
        public Rectangle Area { get; }

        public VerticalWall(Vector2 location)
        {
            this.location = location;
            this.Area = new Rectangle((int)location.X, (int)location.Y, 100, 550);
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
