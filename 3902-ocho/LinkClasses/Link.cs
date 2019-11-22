using Legend_of_zelda_game.CollectableSprites;
using Legend_of_zelda_game.LinkClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public ILinkState previousState;
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
        public LinkPortals LinkPortals;
        public string currentItem;
        public ISet<ICollectable> LinkItems;
        public int numGems;
        public int numKeys;
        public int numBombs;

        public Link(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkIdleDownState(this);
            previousState = state;
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
            LinkPortals = new LinkPortals(this);
            currentItem = "arrow";
            LinkItems = new HashSet<ICollectable>();
            LinkItems.Add(CollectableSpriteFactory.Instance.CreateBombSprite(spriteBatch, new Vector2(0, 0)));
            LinkItems.Add(CollectableSpriteFactory.Instance.CreateBoomerangSprite(spriteBatch, new Vector2(0, 0)));
            LinkItems.Add(CollectableSpriteFactory.Instance.CreateArrowSprite(spriteBatch, new Vector2(0, 0)));
            LinkItems.Add(new CollectablePortalSprite(spriteBatch, new Vector2(0, 0)));
            numGems = 0;
            numKeys = 0;
            numBombs = 5;
        }

        public void Update()
        {
            state.Update();
            previousState = state;
        }
    }
}