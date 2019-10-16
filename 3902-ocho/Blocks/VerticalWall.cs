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
        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public int scale = 1;
        public int width = 100;
        public int height = 550;

        public VerticalWall(Vector2 location)
        {
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
