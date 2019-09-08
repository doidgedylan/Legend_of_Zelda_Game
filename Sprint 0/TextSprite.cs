using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    class TextSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }

        private SpriteFont font;

        public TextSprite(SpriteFont font)
        {
            this.font = font;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Credits", new Vector2(175, 325), Color.Black);
            spriteBatch.DrawString(font, "Program Made By: Evan Standerwick", new Vector2(175, 350), Color.Black);
            spriteBatch.DrawString(font, "Sprites From: https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/", new Vector2(175, 375), Color.Black);
        }

        public void Update()
        {
        }
    }
}
