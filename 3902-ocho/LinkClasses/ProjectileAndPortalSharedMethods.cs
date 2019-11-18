

using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.LinkClasses
{
    class ProjectileAndPortalSharedMethods
    {
        Link link;

        public ProjectileAndPortalSharedMethods(Link link)
        {
            this.link = link;
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

        public bool checkLinkState()
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

        public bool LocationOutOfBounds(Vector2 location)
        {
            bool outOfBounds = false;
            if (location.X < 100 || location.X > 700 ||
                    location.Y < 266 || location.Y > 616)
            {
                outOfBounds = true;
            }
            return outOfBounds;
        }

        public string FindUseItemDirection()
        {
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
            return direct;
        }
    }
}
