

using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Legend_of_zelda_game.EnemySprites
{
    public class EnemyCollisions
    {
        private IEnemies enemy;
        private string[] directions = new string[4];
        
        public EnemyCollisions(IEnemies enemy)
        {
            this.enemy = enemy;
            directions[0] = "up";
            directions[1] = "right";
            directions[2] = "down";
            directions[3] = "left";
        }

        public void Update(ISet<IBlock> blocks)
        {
            if (!enemy.Direction.Equals("none"))
            {
                foreach (IBlock block in blocks)
                {
                    if (EnemyCollision(enemy.LocationRect, block.LocationRect))
                    {
                        enemy.UndoCollision();
                        enemy.Direction = RandomDirection(enemy.Direction);
                    }
                }
            }
        }

        public string RandomDirection(string currentDirection)
        {
            Random random = new Random();
            string[] viableDirections = new string[3];
            string direction = "";
            
            if (currentDirection == "start")
            {
                direction = directions[random.Next(4)];
            }
            else
            {
                int j = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (!directions[i].Equals(currentDirection))
                    {
                        viableDirections[j] = directions[i];
                        j++;
                    }
                }
                direction = viableDirections[random.Next(3)];
            }
            

            return direction;
        }

        public bool EnemyCollision(Rectangle colliderRect, Rectangle collideeRect)
        {
            bool collision = false;

            if (colliderRect.Intersects(collideeRect))
            {
                Rectangle intersect = Rectangle.Intersect(colliderRect, collideeRect);

                if ((intersect.Bottom == collideeRect.Bottom && intersect.Width > intersect.Height) ||
                    (intersect.Top == collideeRect.Top && intersect.Width > intersect.Height) ||
                    (intersect.Left == collideeRect.Left && intersect.Width < intersect.Height) ||
                    (intersect.Right == collideeRect.Right && intersect.Width < intersect.Height))
                {
                    collision = true;
                }
            }

            return collision;
        }
    }
}
