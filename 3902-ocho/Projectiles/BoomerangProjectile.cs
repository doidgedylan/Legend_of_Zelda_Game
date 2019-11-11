using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Projectiles
{
    public class BoomerangProjectile : IProjectile
    {
        Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private bool projectileFinished;
        public bool ProjectileFinished { get => projectileFinished; set => projectileFinished = value; }
        private int moveSpeed = 5;
        private int xPos = 64;
        private int yPos = 185;
        private int width = 8;
        private int height = 16;
        private int scale = 3;
        private string direction;
        private int currentFrame = 0;
        private int totalFrames = 48;

        public BoomerangProjectile(SpriteBatch spriteBatch, Vector2 location, string direction)
        {
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.Location = location;
            this.direction = direction;
            projectileFinished = false;
            SetStartLocation();
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame <= 8)
            {
                xPos = 64;
                DirectionHandlingForward();
            }
            else if (currentFrame > 8 && currentFrame <= 16)
            {
                xPos = 73;
                DirectionHandlingForward();
            }
            else if (currentFrame > 16 && currentFrame <= 24)
            {
                xPos = 82;
                DirectionHandlingForward();
            }
            else if (currentFrame > 24 && currentFrame <= 32)
            {
                xPos = 64;
                DirectionHandlingBackward();
            }
            else if (currentFrame > 32 && currentFrame <= 40)
            {
                xPos = 73;
                DirectionHandlingBackward();
            }
            else if (currentFrame > 40 && currentFrame <= 48)
            {
                xPos = 82;
                DirectionHandlingBackward();
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 25;
            }
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            LocationRect = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White, 0, new Vector2(0, 0), s, 0f);
        }

        public void SetStartLocation()
        {
            switch (direction)
            {
                case "up":
                    Location = Vector2.Add(Location, new Vector2(4 * scale, 0));
                    Location = Vector2.Subtract(location, new Vector2(0, 16 * scale));
                    break;
                case "right":
                    Location = Vector2.Add(Location, new Vector2(16 * scale, 0));
                    break;
                case "down":
                    Location = Vector2.Add(Location, new Vector2(4 * scale, 16 * scale));
                    break;
                case "left":
                    Location = Vector2.Subtract(Location, new Vector2(8 * scale, 0));
                    break;
                default:
                    break;
            }
        }

        public void DirectionHandlingForward()
        {
            switch (direction)
            {
                case "up":
                    Location = Vector2.Subtract(Location, new Vector2(0, moveSpeed));
                    break;
                case "right":
                    Location = Vector2.Add(Location, new Vector2(moveSpeed, 0));
                    break;
                case "down":
                    Location = Vector2.Add(Location, new Vector2(0, moveSpeed));
                    break;
                case "left":
                    Location = Vector2.Subtract(Location, new Vector2(moveSpeed, 0));
                    break;
                default:
                    break;
            }
        }

        public void DirectionHandlingBackward()
        {
            switch (direction)
            {
                case "up":
                    Location = Vector2.Add(Location, new Vector2(0, moveSpeed));
                    break;
                case "right":
                    Location = Vector2.Subtract(Location, new Vector2(moveSpeed, 0));
                    break;
                case "down":
                    Location = Vector2.Subtract(Location, new Vector2(0, moveSpeed));
                    break;
                case "left":
                    Location = Vector2.Add(Location, new Vector2(moveSpeed, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
