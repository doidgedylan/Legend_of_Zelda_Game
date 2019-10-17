using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public interface ICollectable
    {
        Rectangle LocationRect { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
