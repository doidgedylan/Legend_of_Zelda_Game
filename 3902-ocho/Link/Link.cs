using _3902_ocho.Interfaces;
using Legend_of_zelda_game.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public KeyboardController keyboardController;
        public Vector2 location { get; set; }
        public Rectangle locationRect;
        public int moveSpeed;
        public int currentFrame;
        public Color tint;
        public int scale;
        public readonly Color[] hurtColors = new[] { Color.Green, Color.Gray, Color.Red, Color.Black, Color.Orange, Color.DarkRed, Color.Blue };

        public Link(SpriteBatch spriteBatch, KeyboardController keyboardController, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            this.keyboardController = keyboardController;
            state = new LinkIdleDownState(this);
            location = new Vector2(350, 200);
            moveSpeed = 3;
            scale = 3;
            currentFrame = 0;
            tint = Color.White;
            locationRect = new Rectangle((int)location.X, (int)location.Y, 16 * scale, 16 * scale);
        }

        public void Update()
        {
            state.Update();
        }

        public void LinkCollisionBlock(ISet<IBlock> blocks)
        {
            IList<string> blockCollisionSides = new List<string>();
            foreach (IBlock block in blocks)
            {
                string linkCollision = LinkCollison(locationRect, block.LocationRect);
                if (linkCollision != "none")
                {
                    blockCollisionSides.Add(linkCollision);
                }
            }

            if ((blockCollisionSides.Contains("top") && state.GetType().Equals(new LinkMoveUpState(this).GetType())) ||
                (blockCollisionSides.Contains("bottom") && state.GetType().Equals(new LinkMoveDownState(this).GetType())) ||
                (blockCollisionSides.Contains("right") && state.GetType().Equals(new LinkMoveRightState(this).GetType())) ||
                (blockCollisionSides.Contains("left") && state.GetType().Equals(new LinkMoveLeftState(this).GetType())))
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 2;
            }
        }

        public void LinkCollisionEnemy(IBlock[] blocks)
        {
            IList<string> enemyCollisionSides = new List<string>();
            foreach (IBlock block in blocks)
            {
                string linkCollision = LinkCollison(locationRect, block.LocationRect);
                if (linkCollision != "none")
                {
                    enemyCollisionSides.Add(linkCollision);
                }
            }

            if ((enemyCollisionSides.Contains("top") && state.GetType().Equals(new LinkMoveUpState(this).GetType())) ||
                (enemyCollisionSides.Contains("bottom") && state.GetType().Equals(new LinkMoveDownState(this).GetType())) ||
                (enemyCollisionSides.Contains("right") && state.GetType().Equals(new LinkMoveRightState(this).GetType())) ||
                (enemyCollisionSides.Contains("left") && state.GetType().Equals(new LinkMoveLeftState(this).GetType())))
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 2;
            }
        }

        public string LinkCollison(Rectangle colliderRect, Rectangle collideeRect)
        {
            string collisionSide = "none";

            if (colliderRect.Intersects(collideeRect))
            {
                Rectangle intersect = Rectangle.Intersect(colliderRect, collideeRect);

                if (intersect.Bottom == collideeRect.Bottom && intersect.Width > intersect.Height)
                {
                    collisionSide = "top";
                }
                else if (intersect.Top == collideeRect.Top && intersect.Width > intersect.Height)
                {
                    collisionSide = "bottom";
                }
                else if (intersect.Left == collideeRect.Left && intersect.Width < intersect.Height)
                {
                    collisionSide = "right";
                }
                else if (intersect.Right == collideeRect.Right && intersect.Width < intersect.Height)
                {
                    collisionSide = "left";
                }
            }

            return collisionSide;
        }
    }
}
