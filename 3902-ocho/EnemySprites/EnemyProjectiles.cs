using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemyProjectiles
    {
        private Link link;
        private SpriteBatch spriteBatch;
        private SharedProjectileMethods SharedProjectileMethods;

        public EnemyProjectiles(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            SharedProjectileMethods = new SharedProjectileMethods();
        }

        public void Update(ISet<IProjectile> projectiles, ISet<IEnemies> enemies)
        {
            //Add projectile if correct frame in enemy animation
            foreach (IEnemies enemy in enemies)
            {
                if (enemy is EnemiesDragonSprite && enemy.CurrentFrame == 40)
                {
                    projectiles.Add(new DragonFireballProjectile(spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y), "top"));
                    projectiles.Add(new DragonFireballProjectile(spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y), "middle"));
                    projectiles.Add(new DragonFireballProjectile(spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y), "bottom"));
                }
            }

            ISet<IProjectile> projectilesToRemove = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                foreach (IEnemies enemy in enemies)
                {
                    //Check if projectile hit wall
                    if (SharedProjectileMethods.LocationOutOfBounds(projectile.Location))
                    {
                        projectilesToRemove.Add(projectile);
                    }

                    //Check if projectile hit an link
                    if (SharedProjectileMethods.ProjectileCollision(projectile.LocationRect, link.locationRect))
                    {
                        projectilesToRemove.Add(projectile);
                        UpdateLinkDamageState(link.locationRect, projectile.LocationRect);
                        link.HealthStateMachine.BeHurt();
                    }
                }
            }

            //Remove projectiles that should despawn
            foreach (IProjectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
        }

        private void UpdateLinkDamageState(Rectangle colliderRect, Rectangle collideeRect)
        {
            Rectangle intersect = new Rectangle(0, 0, 0, 0);

            if (colliderRect.Intersects(collideeRect))
            {
                intersect = Rectangle.Intersect(colliderRect, collideeRect);

                if (intersect.Bottom == collideeRect.Bottom && intersect.Width > intersect.Height)
                {
                    link.state = new LinkHurtUpState(link);
                }
                else if (intersect.Top == collideeRect.Top && intersect.Width > intersect.Height)
                {
                    link.state = new LinkHurtDownState(link);
                }
                else if (intersect.Left == collideeRect.Left && intersect.Width < intersect.Height)
                {
                    link.state = new LinkHurtRightState(link);
                }
                else if (intersect.Right == collideeRect.Right && intersect.Width < intersect.Height)
                {
                    link.state = new LinkHurtLeftState(link);
                }
            }
        }
    }
}
