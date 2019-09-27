using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    public interface IBlock
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
