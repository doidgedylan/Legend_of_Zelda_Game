using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.Projectiles
{
    public class WoodSwordProjectile : IProjectile
    {
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }

        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private ProjectileCollisions projectileCollisions;
        public ProjectileCollisions ProjectileCollisions { get => projectileCollisions; set => projectileCollisions = value; }

        public WoodSwordProjectile(SpriteBatch spriteBatch, Vector2 location)
        {
            this.spriteBatch = spriteBatch;
            this.Location = location;
        }
        
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
