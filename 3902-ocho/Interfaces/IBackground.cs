using Microsoft.Xna.Framework;
using static _3902_ocho.Door;

namespace Legend_of_zelda_game.Interfaces
{
    public interface IBackground
    {
        void Draw();
        void ScrollIn(Direction direction);
        void ScrollOut(Direction direction);
    }
}
