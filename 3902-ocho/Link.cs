using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3902_ocho
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public Vector2 Location { get; set; }
        public float speed = 2;

        public Link(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkMoveDownState(this);
            Location = new Vector2(350, 200);
        }

        public void Update()
        {
            state.Update();
        }
    }
}
