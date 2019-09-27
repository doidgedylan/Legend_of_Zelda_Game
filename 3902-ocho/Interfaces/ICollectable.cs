using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho
{
    public interface ICollectable
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
