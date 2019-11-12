using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.EnemySprites
{
    class EnemiesWallmasterSprite : IEnemies
    {
        Texture2D spriteSheet;
        SpriteBatch spriteBatch;

        public Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        public HealthStateMachine healthStateMachine;
        public HealthStateMachine HealthStateMachine { get => healthStateMachine; set => healthStateMachine = value; }
        private EnemyCollisions enemyCollisions;
        public EnemyCollisions EnemyCollisions { get => enemyCollisions; set => enemyCollisions = value; }
        private string direction;
        public string Direction { get => direction; set => direction = value; }
        private Vector2 location;

        private int currentFrame = 0;
        private int totalFrames = 20;
        private int xPos = 0;
        private int yPos = 11;
        private int width = 16;
        private int height = 16;
        private int scale = 3;
        private int moveSpeed = 3;

        public EnemiesWallmasterSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteSheet = Texture2DStorage.GetEnemiesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.location = location;
            LocationRect = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            HealthStateMachine = new HealthStateMachine(3, 1);
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

            if (currentFrame <= 10)
            {
                xPos = 393;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 410;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                xPos = 393;
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
