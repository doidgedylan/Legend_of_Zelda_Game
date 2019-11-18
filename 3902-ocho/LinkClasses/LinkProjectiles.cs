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
        private bool bluePortalDeployed;
        private bool redPortalDeployed;
        private string portalCollision;
        private Vector2 bluePortalLocation;
        private Vector2 redPortalLocation;

        public LinkProjectiles(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            projectileInAir = false;
            bluePortalDeployed = false;
            redPortalDeployed = false;
            portalCollision = "none";
            bluePortalLocation = new Vector2(this.link.Location.X, this.link.Location.Y);
            redPortalLocation = new Vector2(this.link.Location.X, this.link.Location.Y);
        }

        public void Update(ISet<IProjectile> projectiles, ISet<IEnemies> enemies, ISet<IBlock> blocks)
        {
            if(checkLinkState())
            {
                if (link.HealthStateMachine.GetHealth() == link.HealthStateMachine.GetTotalHealth())
                {
                    UpdateWoodSwordProjectile(projectiles);
                }
                UpdateItemProjectile(projectiles);
            }

            ISet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                //Check if projectile hit an enemy
                if (!(projectile is BluePortalProjectile) && !(projectile is RedPortalProjectile))
                {
                    foreach (IEnemies enemy in enemies)
                    {
                        //If projectile bomb, dont delete if comes in contanct with enemies
                        //Else delete when comes in contact with enemies
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
                }

                //Check if projectile hit wall
                if(projectileInAir && (projectile.Location.X < 100 || projectile.Location.X > 700 ||
                    projectile.Location.Y < 266 || projectile.Location.Y > 616))
                {
                    projectileInAir = false;
                    projectilesToRemove.Add(projectile);
                }

                //Check if boomerang hit link
                if (projectile is BoomerangProjectile && projectileInAir && ProjectileCollision(projectile.LocationRect, link.locationRect))
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

                //Check if link hit a portal
                if (projectile is BluePortalProjectile)
                {
                    bluePortalLocation = new Vector2(projectile.Location.X, projectile.Location.Y);
                    if (redPortalDeployed && ProjectileCollision(projectile.LocationRect, link.locationRect))
                    {
                        portalCollision = "blue";
                    }
                }
                if (projectile is RedPortalProjectile)
                {
                    redPortalLocation = new Vector2(projectile.Location.X, projectile.Location.Y);
                    if (bluePortalDeployed && ProjectileCollision(projectile.LocationRect, link.locationRect))
                    {
                        portalCollision = "red";
                    }
                }
            }

            //Teleport link if detected portalCollision
            if(portalCollision.Equals("blue"))
            {
                link.Location = new Vector2(redPortalLocation.X, redPortalLocation.Y);
                portalCollision = "none";
            } else if(portalCollision.Equals("red"))
            {
                link.Location = new Vector2(bluePortalLocation.X, bluePortalLocation.Y);
                portalCollision = "none";
            }

            //Remove projectiles that should despawn
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        private bool checkLinkState()
        {
            bool okToAddProjectile = true;

            if ((link.state is LinkWoodSwordDownState || link.state is LinkWoodSwordLeftState ||
                link.state is LinkWoodSwordRightState || link.state is LinkWoodSwordUpState ||
                link.state is LinkUseItemDownState || link.state is LinkUseItemLeftState ||
                link.state is LinkUseItemRightState || link.state is LinkUseItemUpState) &&
                (link.previousState is LinkWoodSwordDownState || link.previousState is LinkWoodSwordLeftState ||
                link.previousState is LinkWoodSwordRightState || link.previousState is LinkWoodSwordUpState ||
                link.previousState is LinkUseItemDownState || link.previousState is LinkUseItemLeftState ||
                link.previousState is LinkUseItemRightState || link.previousState is LinkUseItemUpState))
            {
                okToAddProjectile = false;
            }

            return okToAddProjectile;
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
            //If link is using item in direction, find out which direction
            string direct = "none";
            if (link.state is LinkUseItemDownState)
            {
                direct = "down";
            }
            else if (link.state is LinkUseItemUpState)
            {
                direct = "up";
            }
            else if (link.state is LinkUseItemLeftState)
            {
                direct = "left";
            }
            else if (link.state is LinkUseItemRightState)
            {
                direct = "right";
            }

            //If current item is portals, deal with them
            if (link.currentItem.Equals("portals") && !direct.Equals("none"))
            {
                if (bluePortalDeployed && redPortalDeployed)
                {
                    ISet<IProjectile> portalsToRemove = new HashSet<IProjectile>();
                    foreach (IProjectile projectile in projectiles)
                    {
                        if (projectile is BluePortalProjectile || projectile is RedPortalProjectile)
                        {
                            portalsToRemove.Add(projectile);
                        }
                    }
                    foreach (IProjectile projectile in portalsToRemove)
                    {
                        projectiles.Remove(projectile);
                    }
                    bluePortalDeployed = false;
                    redPortalDeployed = false;
                    projectileInAir = false;
                }
                else if (bluePortalDeployed)
                {
                    projectiles.Add(new RedPortalProjectile(spriteBatch, link.Location, direct));
                    redPortalDeployed = true;
                }
                else
                {
                    projectiles.Add(new BluePortalProjectile(spriteBatch, link.Location, direct));
                    bluePortalDeployed = true;
                }
            }
            
            //Deal with other projectiles
            if (!projectileInAir)
            {
                if (link.state is LinkUseItemDownState || link.state is LinkUseItemUpState ||
                    link.state is LinkUseItemLeftState || link.state is LinkUseItemRightState)
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
