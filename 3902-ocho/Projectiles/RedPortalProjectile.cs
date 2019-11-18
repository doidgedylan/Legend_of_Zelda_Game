using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Projectiles
{
    public class RedPortalProjectile : IProjectile
    {
        Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private bool projectileFinished;
        public bool ProjectileFinished { get => projectileFinished; set => projectileFinished = value; }
        private int xPos = 82;
        private int yPos = 0;
        private int width = 80;
        private int height = 155;
        private int destWidth = 40;
        private int destHeight = 48;
        private string direction;

        public RedPortalProjectile(SpriteBatch spriteBatch, Vector2 location, string direction)
        {
            spriteSheet = Texture2DStorage.GetPortalSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.Location = location;
            this.direction = direction;
            projectileFinished = false;
            SetStartLocation();
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            LocationRect = new Rectangle((int)Location.X, (int)Location.Y, destWidth, destHeight);
            SpriteEffects s = SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White, 0, new Vector2(0, 0), s, 0f);
        }

        public void SetStartLocation()
        {
            switch (direction)
            {
                case "up":
                    Location = Vector2.Add(Location, new Vector2(4, 0));
                    Location = Vector2.Subtract(location, new Vector2(0, 52));
                    break;
                case "right":
                    Location = Vector2.Add(Location, new Vector2(18 * 3, 0));
                    break;
                case "down":
                    Location = Vector2.Add(Location, new Vector2(4, 52));
                    break;
                case "left":
                    Location = Vector2.Subtract(Location, new Vector2(destWidth + 4, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
