using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.Projectiles
{
    class SharedProjectileMethods
    {
        public SharedProjectileMethods()
        {
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
    }
}
