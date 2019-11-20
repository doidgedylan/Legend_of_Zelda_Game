using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Projectiles
{
    public class DragonFireballProjectile : IProjectile
    {
        Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private bool projectileFinished;
        public bool ProjectileFinished { get => projectileFinished; set => projectileFinished = value; }
        private int xMoveSpeed = 3;
        private int yMoveSpeed = 1;
        private int xPos = 0;
        private int yPos = 14;
        private int width = 8;
        private int height = 10;
        private int scale = 3;
        private int currentFrame = 0;
        private int totalFrames = 40;
        private string direction;

        public DragonFireballProjectile(SpriteBatch spriteBatch, Vector2 location, string direction)
        {
            spriteSheet = Texture2DStorage.GetBossesSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.Location = location;
            this.direction = direction;
            projectileFinished = false;
            SetStartLocation();
        }
        
        public void Update()
        {
            DirectionHandling();

            currentFrame++;
            if (currentFrame < 10)
            {
                xPos = 101;
            }
            else if (currentFrame > 10 && currentFrame <= 20)
            {
                xPos = 110;
            }
            else if (currentFrame > 20 && currentFrame <= 30)
            {
                xPos = 119;
            }
            else if (currentFrame > 30 && currentFrame <= 40)
            {
                xPos = 128;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            LocationRect = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White);
        }

        public void SetStartLocation()
        {
            Location = Vector2.Add(Location, new Vector2(0, 8 * scale));
            Location = Vector2.Subtract(Location, new Vector2(8 * scale, 0));
        }

        public void DirectionHandling()
        {
            switch (direction)
            {
                case "top":
                    Location = Vector2.Subtract(Location, new Vector2(xMoveSpeed, yMoveSpeed));
                    break;
                case "middle":
                    Location = Vector2.Subtract(Location, new Vector2(xMoveSpeed + yMoveSpeed, 0));
                    break;
                case "bottom":
                    Location = Vector2.Add(Location, new Vector2(0, yMoveSpeed));
                    Location = Vector2.Subtract(Location, new Vector2(xMoveSpeed, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
