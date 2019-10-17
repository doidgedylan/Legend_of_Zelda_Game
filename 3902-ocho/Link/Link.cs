using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game
{
    public class Link
    {
        public ILinkState state;
        public SpriteBatch spriteBatch;
        public Vector2 location { get; set; }
        public Rectangle locationRect;
        public int moveSpeed;
        public int hurtSpeed;
        public int currentFrame;
        public Color tint;
        public int scale;
        public readonly Color[] hurtColors = new[] { Color.Green, Color.Gray, Color.Red, Color.Black, Color.Orange, Color.DarkRed, Color.Blue };

        public Link(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            state = new LinkIdleDownState(this);
            location = new Vector2(350, 200);
            moveSpeed = 3;
            hurtSpeed = 5;
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

            if ((blockCollisionSides.Contains("top") && state is LinkMoveUpState) ||
                (blockCollisionSides.Contains("bottom") && state is LinkMoveDownState) ||
                (blockCollisionSides.Contains("right") && state is LinkMoveRightState) ||
                (blockCollisionSides.Contains("left") && state is LinkMoveLeftState))
            {
                moveSpeed = 0;
            }
            else if ((blockCollisionSides.Contains("top") && state is LinkHurtDownState) ||
                (blockCollisionSides.Contains("bottom") && state is LinkHurtUpState) ||
                (blockCollisionSides.Contains("right") && state is LinkHurtLeftState) ||
                (blockCollisionSides.Contains("left") && state is LinkHurtRightState))
            {
                hurtSpeed = 0;
            }
            else
            {
                moveSpeed = 3;
                hurtSpeed = 5;
            }
        }

        public void LinkCollisionEnemy(ISet<IEnemies> enemies)
        {
            IList<string> enemyCollisionSides = new List<string>();
            foreach (IEnemies enemy in enemies)
            {
                string linkCollision = LinkCollison(locationRect, enemy.LocationRect);
                if (linkCollision != "none")
                {
                    enemyCollisionSides.Add(linkCollision);
                }
            }

            if (enemyCollisionSides.Contains("bottom") && state is LinkMoveDownState)
            {
                state = new LinkHurtDownState(this);
            }
            else if (enemyCollisionSides.Contains("top") && state is LinkMoveUpState)
            {
                state = new LinkHurtUpState(this);
            }
            else if (enemyCollisionSides.Contains("left") && state is LinkMoveLeftState)
            {
                state = new LinkHurtLeftState(this);
            }
            else if (enemyCollisionSides.Contains("right") && state is LinkMoveRightState)
            {
                state = new LinkHurtRightState(this);
            }
            else
            {
                moveSpeed = 3;
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
