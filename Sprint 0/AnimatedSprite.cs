using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public class AnimatedSprite : ISprite
    {
        // code adapted from http://rbwhitaker.wikidot.com/monogame-texture-atlases-2http://rbwhitaker.wikidot.com/monogame-texture-atlases-2
        // code also adapted from http://web.cse.ohio-state.edu/~boggus.2/3902/slides/ManualAnimatedSprite.cs
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedSprite(Texture2D texture, int x, int y, int rows, int columns)
        {
            Texture = texture;
            this.Location = new Vector2(x, y);
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(0, 0, 116, 133);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 116, 133);
            }
            else // if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(116, 0, 125, 133);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 125, 133);
            }

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
