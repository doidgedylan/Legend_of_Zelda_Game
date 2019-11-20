

using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.Interfaces
{
    public interface ITitleScreen
    {
        Vector2 Location { get; set; }
        void Update();
        void Draw();
    }
}
