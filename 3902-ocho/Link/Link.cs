using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public Vector2 location { get; set; }
        public float speed;
        public int currentFrame;
        public Color tint;

        public Link(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkIdleDownState(this);
            this.location = location;
            speed = 2;
            currentFrame = 0;
            tint = Color.White;
        }

        public void Update()
        {
            state.Update();
        }
    }
}
