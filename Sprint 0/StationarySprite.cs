using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0
{
    public class StationarySprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public StationarySprite(Texture2D texture, int x, int y)
        {
            this.Texture = texture;
            this.Location = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle((int)Location.X, (int)Location.Y, Texture.Width, Texture.Height), Color.White);
        }

        public void Update()
        {
            
        }
    }
}
