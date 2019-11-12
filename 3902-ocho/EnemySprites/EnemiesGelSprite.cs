using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesGelSprite : IEnemies
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
        private int totalFrames = 6;
        private int xPos = 0;
        private int yPos = 15;
        private int width = 8;
        private int height = 9;
        private int scale = 3;
        private int moveSpeed = 4;

        public EnemiesGelSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            HealthStateMachine = new HealthStateMachine(1, 1);
            EnemyCollisions = new EnemyCollisions(this);
            direction = EnemyCollisions.RandomDirection("start");
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
        public void UndoCollision()
        {
            switch (Direction)
            {
                case "up":
                    location = Vector2.Add(location, new Vector2(0, moveSpeed));
                    break;
                case "right":
                    location = Vector2.Subtract(location, new Vector2(moveSpeed, 0));
                    break;
                case "down":
                    location = Vector2.Subtract(location, new Vector2(0, moveSpeed));
                    break;
                case "left":
                    location = Vector2.Add(location, new Vector2(moveSpeed, 0));
                    break;
                default:
                    break;
            }
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

        private void ApplyAnimation()
        {
            currentFrame++;

            if (currentFrame <= 3)
            {
                xPos = 1;
            }
            else if (currentFrame > 3 && currentFrame <= 6)
            {
                xPos = 10;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 1;
            }
        }

        private void ApplyMovement()
        {
            switch (Direction)
            {
                case "up":
                    location = Vector2.Subtract(location, new Vector2(0, moveSpeed));
                    break;
                case "right":
                    location = Vector2.Add(location, new Vector2(moveSpeed, 0));
                    break;
                case "down":
                    location = Vector2.Add(location, new Vector2(0, moveSpeed));
                    break;
                case "left":
                    location = Vector2.Subtract(location, new Vector2(moveSpeed, 0));
                    break;
                default:
                    break;
            }
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
        }

    }
}
