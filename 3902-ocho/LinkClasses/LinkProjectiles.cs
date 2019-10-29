

using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game.LinkClasses
{
    public class LinkProjectiles
    {
        private Link link;
        private SpriteBatch spriteBatch;
        private bool woodswordInAir;

        public LinkProjectiles(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            woodswordInAir = false;
        }

        public void Update(ISet<IProjectile> projectiles, ISet<IEnemies> enemies, ISet<IBlock> blocks)
        {
            if (!woodswordInAir)
            {
                if (link.state is LinkWoodSwordDownState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "down"));
                    woodswordInAir = true;
                }
                else if (link.state is LinkWoodSwordUpState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "up"));
                    woodswordInAir = true;
                }
                else if (link.state is LinkWoodSwordLeftState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "left"));
                    woodswordInAir = true;
                }
                else if (link.state is LinkWoodSwordRightState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "right"));
                    woodswordInAir = true;
                }
            }

            ISet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            ISet<IEnemies> enemiesToRemove = new HashSet<IEnemies>();
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IEnemies enemy in enemies)
                {
                    if (woodswordInAir && ProjectileCollision(projectile.LocationRect, enemy.LocationRect))
                    {
                        woodswordInAir = false;
                        projectilesToRemove.Add(projectile);
                        enemiesToRemove.Add(enemy);
                    }
                }
                foreach (IBlock block in blocks)
                {
                    if (woodswordInAir && (block is HorizontalWall || block is VerticalWall) &&
                        ProjectileCollision(projectile.LocationRect, block.LocationRect))
                    {
                        woodswordInAir = false;
                        projectilesToRemove.Add(projectile);
                    }
                }
            }
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
            foreach (IEnemies enemy in enemiesToRemove)
            {
                enemies.Remove(enemy);
            }
        }

        public bool ProjectileCollision(Rectangle colliderRect, Rectangle collideeRect)
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
