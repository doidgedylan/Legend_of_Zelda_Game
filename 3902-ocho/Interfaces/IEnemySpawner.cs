using Legend_of_zelda_game.EnemySpawners;
using Legend_of_zelda_game.EnemySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Interfaces
{
    public interface IEnemySpawner
    {
        Rectangle LocationRect { get; set; }
        HealthStateMachine HealthStateMachine { get; set; }
        SpawnEnemy SpawnEnemy { get; set; }
        void Update();
        void Draw();
    }
}
