﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public Vector2 Location { get; set; }
        public float speed;
        public int currentFrame;
        public Color tint;

        public Link(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkIdleDownState(this);
            Location = new Vector2(350, 200);
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
