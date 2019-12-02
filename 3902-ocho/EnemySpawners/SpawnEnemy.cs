using Legend_of_zelda_game.EnemySprites;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game.EnemySpawners
{
    public class SpawnEnemy
    {
        private SpriteBatch spriteBatch;
        private Vector2 location;
        private string enemyType;
        private int timer;
        private int numStartEnemies;
        private int numEnemies;
        public SpawnEnemy(SpriteBatch spriteBatch, Vector2 location, string enemyType)
        {
            this.spriteBatch = spriteBatch;
            this.location = location;
            this.enemyType = enemyType;
            timer = 0;
        }

        public void Update(ISet<IEnemies> enemies)
        {
            if (timer == 0)
            {
                numStartEnemies = enemies.Count;
                numEnemies = enemies.Count;
            } 
            else
            {
                numEnemies = enemies.Count;
            }

            timer++;
            if(timer%50 == 0 && numEnemies <= numStartEnemies + 10)
            {
                switch (enemyType)
                {
                    case "Stalfos":
                        enemies.Add(new EnemiesStalfosSprite(spriteBatch, location));
                        break;
                    default:
                        break;
                }
            }

            if (timer == 999)
            {
                timer = 1;
            }
        }
    }
}
