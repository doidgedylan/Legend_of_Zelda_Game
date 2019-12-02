using Legend_of_zelda_game.EnemySprites;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySpawners
{
    public class EnemySpawner : IEnemySpawner
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public HealthStateMachine healthStateMachine;
        public HealthStateMachine HealthStateMachine { get => healthStateMachine; set => healthStateMachine = value; }
        public SpawnEnemy spawnEnemy;
        public SpawnEnemy SpawnEnemy { get => spawnEnemy; set => spawnEnemy = value; }

        private int xPos = 0;
        private int yPos = 0;
        private int width = 32;
        private int height = 32;

        public EnemySpawner(SpriteBatch spriteBatch, Vector2 location, string enemyType)
        {
            spriteSheet = Texture2DStorage.GetEnemySpawnerSpriteSheet();
            this.spriteBatch = spriteBatch;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, 48, 48);
            HealthStateMachine = new HealthStateMachine(4, 1);
            SpawnEnemy = new SpawnEnemy(spriteBatch, location, enemyType);
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }
    }
}
