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
        private bool projectileInAir;

        public LinkProjectiles(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            projectileInAir = false;
        }

        public void Update(ISet<IProjectile> projectiles, ISet<IEnemies> enemies, ISet<IBlock> blocks)
        {
            UpdateWoodSwordProjectile(projectiles);
            UpdateItemProjectile(projectiles);

            ISet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IEnemies enemy in enemies)
                {
                    if (projectile is BombProjectile && ProjectileCollision(projectile.LocationRect, enemy.LocationRect))
                    {
                        enemy.HealthStateMachine.BeHurt(); ;
                    }
                    else if (projectileInAir && ProjectileCollision(projectile.LocationRect, enemy.LocationRect))
                    {
                        projectileInAir = false;
                        projectilesToRemove.Add(projectile);
                        enemy.HealthStateMachine.BeHurt(); ;
                    }
                }
                if(projectileInAir && (projectile.Location.X < 100 || projectile.Location.X > 700 ||
                    projectile.Location.Y < 266 || projectile.Location.Y > 616))
                {
                    projectileInAir = false;
                    projectilesToRemove.Add(projectile);
                }

                if (projectile is BoomerangProjectile && projectileInAir && ProjectileCollision(projectile.LocationRect, link.locationRect))
                {
                    projectileInAir = false;
                    projectilesToRemove.Add(projectile);
                }

                if (projectile is BombProjectile && projectile.ProjectileFinished)
                {
                    projectilesToRemove.Add(projectile);
                    projectileInAir = false;
                }
            }
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        public void UpdateWoodSwordProjectile(ISet<IProjectile> projectiles)
        {
            if (!projectileInAir)
            {
                if (link.state is LinkWoodSwordDownState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "down"));
                    projectileInAir = true;
                }
                else if (link.state is LinkWoodSwordUpState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "up"));
                    projectileInAir = true;
                }
                else if (link.state is LinkWoodSwordLeftState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "left"));
                    projectileInAir = true;
                }
                else if (link.state is LinkWoodSwordRightState)
                {
                    projectiles.Add(new WoodSwordProjectile(spriteBatch, link.Location, "right"));
                    projectileInAir = true;
                }
            }
        }

        public void UpdateItemProjectile(ISet<IProjectile> projectiles)
        {
            if (!projectileInAir)
            {
                string direct = "none";
                if (link.state is LinkUseItemDownState)
                {
                    direct = "down";
                    projectileInAir = true;
                }
                else if (link.state is LinkUseItemUpState)
                {
                    direct = "up";
                    projectileInAir = true;
                }
                else if (link.state is LinkUseItemLeftState)
                {
                    direct = "left";
                    projectileInAir = true;
                }
                else if (link.state is LinkUseItemRightState)
                {
                    direct = "right";
                    projectileInAir = true;
                }

                if(projectileInAir)
                {
                    if (link.currentItem.Equals("arrow"))
                    {
                        projectiles.Add(new ArrowProjectile(spriteBatch, link.Location, direct));
                    }
                    else if (link.currentItem.Equals("bomb"))
                    {
                        projectiles.Add(new BombProjectile(spriteBatch, link.Location, direct));
                    }
                    else if (link.currentItem.Equals("boomerang"))
                    {
                        projectiles.Add(new BoomerangProjectile(spriteBatch, link.Location, direct));
                    }
                }
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
