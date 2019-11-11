using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Interfaces
{
    public interface IProjectile
    {
        Vector2 Location { get; set; }
        Rectangle LocationRect { get; set; }
        bool ProjectileFinished { get; set; }
        void Update();
        void Draw();
    }
}
