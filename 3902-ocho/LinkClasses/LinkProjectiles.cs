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
        private SharedLinkProjectileMethods SharedLinkProjectileMethods;
        private SharedProjectileMethods SharedProjectileMethods;

        public LinkProjectiles(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            projectileInAir = false;
            SharedLinkProjectileMethods = new SharedLinkProjectileMethods(this.link);
            SharedProjectileMethods = new SharedProjectileMethods();
        }

        public void Update(ISet<IProjectile> projectiles, ISet<IEnemies> enemies)
        {
            if (SharedLinkProjectileMethods.checkLinkState())
            {
                if (link.HealthStateMachine.GetHealth() == link.HealthStateMachine.GetTotalHealth())
                {
                    AddWoodSwordProjectile(projectiles);
                }
                AddItemProjectile(projectiles);
            }

            ISet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                //Check if projectile hit an enemy
                foreach (IEnemies enemy in enemies)
                {
                    //If projectile bomb, dont delete if comes in contanct with enemies
                    //Else delete when comes in contact with enemies
                    if (projectile is BombProjectile && SharedProjectileMethods.ProjectileCollision(projectile.LocationRect, enemy.LocationRect))
                    {
                        enemy.HealthStateMachine.BeHurt(); ;
                    }
                    else if (projectileInAir && SharedProjectileMethods.ProjectileCollision(projectile.LocationRect, enemy.LocationRect))
                    {
                        projectileInAir = false;
                        projectilesToRemove.Add(projectile);
                        enemy.HealthStateMachine.BeHurt(); ;
                    }
                }

                //Check if projectile hit wall
                if(projectileInAir && SharedProjectileMethods.LocationOutOfBounds(projectile.Location))
                {
                    projectileInAir = false;
                    projectilesToRemove.Add(projectile);
                }

                //Check if boomerang hit link
                if (projectile is BoomerangProjectile && projectileInAir && SharedProjectileMethods.ProjectileCollision(projectile.LocationRect, link.locationRect))
                {
                    projectileInAir = false;
                    projectilesToRemove.Add(projectile);
                }

                //Check if bomb is done with animation
                if (projectile is BombProjectile && projectile.ProjectileFinished)
                {
                    projectilesToRemove.Add(projectile);
                    projectileInAir = false;
                }
            }

            //Remove projectiles that should despawn
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        public void AddWoodSwordProjectile(ISet<IProjectile> projectiles)
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

        public void AddItemProjectile(ISet<IProjectile> projectiles)
        {
            string direct = SharedLinkProjectileMethods.FindUseItemDirection();

            if (!projectileInAir)
            {
                if (!link.currentItem.Equals("portals") && (link.state is LinkUseItemDownState || link.state is LinkUseItemUpState ||
                    link.state is LinkUseItemLeftState || link.state is LinkUseItemRightState))
                {
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
    }
}
