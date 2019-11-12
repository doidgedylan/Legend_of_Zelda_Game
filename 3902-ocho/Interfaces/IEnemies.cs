using Legend_of_zelda_game.EnemySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Interfaces
{
    public interface IEnemies
    {
        Rectangle LocationRect { get; set; }
        HealthStateMachine HealthStateMachine { get; set; }
        EnemyCollisions EnemyCollisions { get; set; }
        string Direction { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void UndoCollision();
    }
}
