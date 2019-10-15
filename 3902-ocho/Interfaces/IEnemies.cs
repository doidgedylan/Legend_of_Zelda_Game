using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public interface IEnemies
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
