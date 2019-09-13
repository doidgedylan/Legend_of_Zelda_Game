using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public interface ISprite
    {
        Vector2 Location { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
