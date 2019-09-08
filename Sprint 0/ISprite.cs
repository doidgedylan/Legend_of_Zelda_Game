﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        Vector2 Location { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
