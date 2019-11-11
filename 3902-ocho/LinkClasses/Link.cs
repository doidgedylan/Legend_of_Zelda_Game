using Legend_of_zelda_game.LinkClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public Vector2 Location { get; set; }
        public Rectangle locationRect;
        public int moveSpeed;
        public int hurtSpeed;
        public int currentFrame;
        public Color tint;
        public int scale;
        public readonly Color[] hurtColors = new[] { Color.Green, Color.Gray, Color.Red, Color.Black, Color.Orange, Color.DarkRed, Color.Blue };
        public HealthStateMachine HealthStateMachine;
        public LinkCollisions LinkCollisions;
        public LinkProjectiles LinkProjectiles;
        public string currentItem;
        public ISet<ICollectable> LinkItems;
        public int numGems;
        public int numKeys;
        public int numBombs;

        public Link(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkIdleDownState(this);
            this.Location = location;
            moveSpeed = 3;
            hurtSpeed = 5;
            scale = 3;
            currentFrame = 0;
            tint = Color.White;
            locationRect = new Rectangle((int)location.X, (int)location.Y, 16 * scale, 16 * scale);
            HealthStateMachine = new HealthStateMachine(6,1);
            LinkCollisions = new LinkCollisions(this);
            LinkProjectiles = new LinkProjectiles(this);
            currentItem = "boomerang";
            LinkItems = new HashSet<ICollectable>();
            numGems = 0;
            numKeys = 0;
            numBombs = 5;
        }

        public void Update()
        {
            state.Update();
        }
    }
}