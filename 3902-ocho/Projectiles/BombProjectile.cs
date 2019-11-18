using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Projectiles
{
    public class BombProjectile : IProjectile
    {
        Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private bool projectileFinished;
        public bool ProjectileFinished { get => projectileFinished; set => projectileFinished = value; }
        private int xPos = 129;
        private int yPos = 185;
        private int width = 8;
        private int height = 16;
        private int scale = 3;
        private string direction;
        private float rotation = 0;
        private int currentFrame = 0;
        private int totalFrames = 80;

        public BombProjectile(SpriteBatch spriteBatch, Vector2 location, string direction)
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

            if (currentFrame <= 50)
            {
                xPos = 129;
                width = 8;
            }
            else if (currentFrame > 50 && currentFrame <= 60)
            {
                xPos = 138;
                width = 16;
            }
            else if (currentFrame > 60 && currentFrame <= 70)
            {
                xPos = 155;
                width = 16;
            }
            else if (currentFrame > 70 && currentFrame <= 80)
            {
                xPos = 172;
                width = 16;
            }

            if (currentFrame == 51)
            {
                Location = Vector2.Subtract(Location, new Vector2(4 * scale, 0));
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                projectileFinished = true;
            }

            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            LocationRect = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);
            SpriteEffects s = SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White, rotation, new Vector2(0, 0), s, 0f);
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
    }
}
