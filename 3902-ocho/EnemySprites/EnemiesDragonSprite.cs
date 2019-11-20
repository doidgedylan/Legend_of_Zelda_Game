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

        private int currentFrame;
        public int CurrentFrame { get => currentFrame; set => currentFrame = value; }
        private Vector2 location;

        private float moveSpeed = 1;
        private int totalFrames = 80;
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
            Direction = "none";
            CurrentFrame = 0;
        }

        public void Update()
        {
            ApplyAnimation();
            ApplyMovement();
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

            if (currentFrame <= 20)
            {
                xPos = 1;
            }
            else if (currentFrame > 20 && currentFrame <= 40)
            {
                xPos = 26;
            }
            else if (currentFrame > 40 && currentFrame <= 60)
            {
                xPos = 51;
            }
            else if (currentFrame > 60 && currentFrame <= 80)
            {
                xPos = 76;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
            }
        }

        private void ApplyMovement()
        {
            if(currentFrame > 20 && currentFrame <= 40)
            {
                location = Vector2.Subtract(location, new Vector2(moveSpeed, 0));
            }
            else if (currentFrame > 60 && currentFrame <= 80)
            {
                location = Vector2.Add(location, new Vector2(moveSpeed, 0));
            }
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        public void UndoCollision()
        {
            //Do Nothing
        }
    }
}
