using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public class MovingSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public MovingSprite(Texture2D texture, int x, int y)
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
            float newY = Location.Y + 1;
            if (newY >= 480)
            {
                newY = -133;
            }
            Location = new Vector2(Location.X, newY);
        }
    }
}
