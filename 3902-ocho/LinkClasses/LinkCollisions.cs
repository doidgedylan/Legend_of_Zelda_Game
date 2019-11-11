using _3902_ocho.GameStates;
using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.CollectableSprites;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Legend_of_zelda_game.LinkClasses
{
    public class LinkCollisions
    {
        Link link;

        public LinkCollisions(Link link)
        {
            this.link = link;
        }

        public void Update(ISet<ICollectable> collectables, ISet<IEnemies> enemies, ISet<IBlock> blocks, StateManager stateManager)
        {
            LinkCollisionCollectable(collectables);
            LinkCollisionEnemy(enemies);
            LinkCollisionBlock(blocks, stateManager);
        }

        public void LinkCollisionBlock(ISet<IBlock> blocks, StateManager stateManager)
        {
            IList<string> blockCollisionSides = new List<string>();
            IList<IBlock> blocksCollided = new List<IBlock>();
            Dictionary<Rectangle, string> blockCollisions = new Dictionary<Rectangle, string>();
            foreach (IBlock block in blocks)
            {
                Tuple<string, Rectangle> collisionTuple = LinkCollison(link.locationRect, block.LocationRect);
                string linkCollision = collisionTuple.Item1;
                Rectangle intersect = collisionTuple.Item2;
                if (linkCollision != "none")
                {
                    if (!blockCollisions.ContainsKey(intersect))
                    {
                        blockCollisions.Add(intersect, linkCollision);
                    }
                    blockCollisionSides.Add(linkCollision);
                    blocksCollided.Add(block);
                }
            }

            bool collisionDetected = false;
            int maxArea = 0;
            Rectangle MaxAreaRect = new Rectangle(0, 0, 0, 0);
            bool equalAreas = false;
            foreach (KeyValuePair<Rectangle, string> item in blockCollisions)
            {
                Rectangle rect = item.Key;
                int area = rect.Width * rect.Height;
                if (area > maxArea)
                {
                    maxArea = area;
                    MaxAreaRect = rect;
                }
                else if (area == maxArea || maxArea - area <= 64)
                {
                    equalAreas = true;
                }
            }

            if (equalAreas)
            {
                if ((blockCollisionSides.Contains("top") && link.state is LinkMoveUpState) ||
                    (blockCollisionSides.Contains("bottom") && link.state is LinkMoveDownState) ||
                    (blockCollisionSides.Contains("right") && link.state is LinkMoveRightState) ||
                    (blockCollisionSides.Contains("left") && link.state is LinkMoveLeftState))
                {
                    link.moveSpeed = 0;
                    collisionDetected = true;
                }
                else if ((blockCollisionSides.Contains("top") && link.state is LinkHurtDownState) ||
                    (blockCollisionSides.Contains("bottom") && link.state is LinkHurtUpState) ||
                    (blockCollisionSides.Contains("right") && link.state is LinkHurtLeftState) ||
                    (blockCollisionSides.Contains("left") && link.state is LinkHurtRightState))
                {
                    link.hurtSpeed = 0;
                    collisionDetected = true;
                }
                else
                {
                    link.moveSpeed = 3;
                    link.hurtSpeed = 5;
                }
            }
            else if (blockCollisions.ContainsKey(MaxAreaRect))
            {
                string val = blockCollisions[MaxAreaRect];
                if ((val.Equals("top") && link.state is LinkMoveUpState) ||
                    (val.Equals("bottom") && link.state is LinkMoveDownState) ||
                    (val.Equals("right") && link.state is LinkMoveRightState) ||
                    (val.Equals("left") && link.state is LinkMoveLeftState))
                {
                    link.moveSpeed = 0;
                    collisionDetected = true;
                }
                else if ((val.Equals("top") && link.state is LinkHurtDownState) ||
                    (val.Equals("bottom") && link.state is LinkHurtUpState) ||
                    (val.Equals("right") && link.state is LinkHurtLeftState) ||
                    (val.Equals("left") && link.state is LinkHurtRightState))
                {
                    link.hurtSpeed = 0;
                    collisionDetected = true;
                }
                else
                {
                    link.moveSpeed = 3;
                    link.hurtSpeed = 5;
                }
            }

            if(collisionDetected)
            {
                foreach(IBlock block in blocksCollided)
                {
                    if (block is Door)
                    {
                        if(link.numKeys < 0)
                        {
                            link.numKeys--;
                        }
                        stateManager.RoomTransition(block as Door);
                        link.moveSpeed = 3;
                        link.hurtSpeed = 5;
                    }
                }
            }
        }

        public void LinkCollisionEnemy(ISet<IEnemies> enemies)
        {
            IList<string> enemyCollisionSides = new List<string>();
            IList<IEnemies> enemyCollisions = new List<IEnemies>();
            foreach (IEnemies enemy in enemies)
            {
                string linkCollision = LinkCollison(link.locationRect, enemy.LocationRect).Item1;
                if (linkCollision != "none")
                {
                    enemyCollisionSides.Add(linkCollision);
                    enemyCollisions.Add(enemy);
                }
            }

            if (enemyCollisionSides.Contains("bottom") && link.state is LinkMoveDownState)
            {
                link.state = new LinkHurtDownState(link);
                link.HealthStateMachine.BeHurt();
            }
            else if (enemyCollisionSides.Contains("top") && link.state is LinkMoveUpState)
            {
                link.state = new LinkHurtUpState(link);
                link. HealthStateMachine.BeHurt();
            }
            else if (enemyCollisionSides.Contains("left") && link.state is LinkMoveLeftState)
            {
                link.state = new LinkHurtLeftState(link);
                link.HealthStateMachine.BeHurt();
            }
            else if (enemyCollisionSides.Contains("right") && link.state is LinkMoveRightState)
            {
                link.state = new LinkHurtRightState(link);
                link.HealthStateMachine.BeHurt();
            }
            else if ((enemyCollisionSides.Contains("bottom") && link.state is LinkWoodSwordDownState) ||
                (enemyCollisionSides.Contains("top") && link.state is LinkWoodSwordUpState) ||
                (enemyCollisionSides.Contains("left") && link.state is LinkWoodSwordLeftState) ||
                (enemyCollisionSides.Contains("right") && link.state is LinkWoodSwordRightState))
            {
                foreach (IEnemies enemy in enemyCollisions)
                {
                    if (!(enemy is EnemiesTrapSprite))
                    {
                        enemies.Remove(enemy);
                    }
                }
            }
        }

        public void LinkCollisionCollectable(ISet<ICollectable> collectables)
        {
            IList<string> collectableCollisionSides = new List<string>();
            IList<ICollectable> collectableCollisions = new List<ICollectable>();
            foreach (ICollectable collectable in collectables)
            {
                string linkCollision = LinkCollison(link.locationRect, collectable.LocationRect).Item1;
                if (linkCollision != "none")
                {
                    collectableCollisionSides.Add(linkCollision);
                    collectableCollisions.Add(collectable);
                }
            }

            if ((collectableCollisionSides.Contains("top") && link.state is LinkMoveUpState) ||
                (collectableCollisionSides.Contains("bottom") && link.state is LinkMoveDownState) ||
                (collectableCollisionSides.Contains("right") && link.state is LinkMoveRightState) ||
                (collectableCollisionSides.Contains("left") && link.state is LinkMoveLeftState))
            {
                foreach (ICollectable collectable in collectableCollisions)
                {
                    if(collectable is CollectableSingleRupeeSprite)
                    {
                        link.numGems++;
                    }
                    else if (collectable is CollectableKeySprite)
                    {
                        link.numKeys++;
                    }
                    else if(collectable is CollectableBombSprite)
                    {
                        link.numBombs++;
                    } 
                    else if (collectable is CollectableTriforceSprite)
                    {
                        link.currentItem = "Triforce";
                    }
                    else if (collectable is CollectableSwordSprite || 
                        collectable is CollectableBowSprite ||
                        collectable is CollectableBoomerangSprite ||
                        collectable is CollectableBombSprite)
                    {
                        link.LinkItems.Add(collectable);
                        link.state = new LinkPickUpItemState(link);
                    }
                    collectables.Remove(collectable);
                }
            }
        }

        public Tuple<string, Rectangle> LinkCollison(Rectangle colliderRect, Rectangle collideeRect)
        {
            string collisionSide = "none";
            Rectangle intersect = new Rectangle(0,0,0,0);

            if (colliderRect.Intersects(collideeRect))
            {
                intersect = Rectangle.Intersect(colliderRect, collideeRect);

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
            Tuple<string, Rectangle> collisionTuple = new Tuple<string, Rectangle>(collisionSide, intersect);

            return collisionTuple;
        }
    }
}
