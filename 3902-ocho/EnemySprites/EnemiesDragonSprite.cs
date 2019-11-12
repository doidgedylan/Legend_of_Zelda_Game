using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    public class EnemiesDragonSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private HealthStateMachine healthStateMachine;
        public HealthStateMachine HealthStateMachine { get => healthStateMachine; set => healthStateMachine = value; }
        private EnemyCollisions enemyCollisions;
        public EnemyCollisions EnemyCollisions { get => enemyCollisions; set => enemyCollisions = value; }
        private string direction;
        public string Direction { get => direction; set => direction = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 10;
        private int width = 24;
        private int height = 32;
        private int scale = 3;

        public EnemiesDragonSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetBossesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            HealthStateMachine = new HealthStateMachine(10, 1);
            EnemyCollisions = new EnemyCollisions(this);
            direction = "none";
        }

        public void Update()
        {
            ApplyAnimation();
            Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 10)
            {
                xPos = 1;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 26;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
            }
        }
        public void UndoCollision()
        {
            //Do Nothing
        }
    }
}
