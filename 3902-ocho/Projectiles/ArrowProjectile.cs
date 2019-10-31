using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.Projectiles
{
    public class ArrowProjectile : IProjectile
    {
        Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public Vector2 Location { get => location; set => location = value; }
        private Rectangle locationRect;
        public Rectangle LocationRect { get => locationRect; set => locationRect = value; }
        private int moveSpeed = 5;
        private int xPos = 154;
        private int yPos = 0;
        private int width = 5;
        private int height = 16;
        private int scale = 3;
        private string direction;
        private float rotation = 0;

        public ArrowProjectile(SpriteBatch spriteBatch, Vector2 location, string direction)
        {
            spriteSheet = Texture2DStorage.GetCollectableSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.Location = location;
            this.direction = direction;
            SetStartLocation();
        }
        
        public void Update()
        {
            DirectionHandling();
            Draw();
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(xPos, yPos, width, height);
            LocationRect = new Rectangle((int)Location.X, (int)Location.Y, width * scale, height * scale);
            SpriteEffects s = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(spriteSheet, LocationRect, sourceRectangle, Color.White, rotation, new Vector2(0, 0), s, 0f);
        }

        public void SetStartLocation()
        {
            switch (direction)
            {
                case "up":
                    Location = Vector2.Add(Location, new Vector2(6 * scale, 0));
                    Location = Vector2.Subtract(location, new Vector2(0, 16 * scale));
                    break;
                case "right":
                    Location = Vector2.Add(Location, new Vector2(16 * scale * 2, 6 * scale));
                    break;
                case "down":
                    Location = Vector2.Add(Location, new Vector2(11 * scale, 16 * scale * 2));
                    break;
                case "left":
                    Location = Vector2.Add(Location, new Vector2(0, 11 * scale));
                    Location = Vector2.Subtract(Location, new Vector2(16 * scale, 0));
                    break;
                default:
                    break;
            }
        }

        public void DirectionHandling()
        {
            switch (direction)
            {
                case "up":
                    rotation = 0;
                    Location = Vector2.Subtract(Location, new Vector2(0, moveSpeed));
                    break;
                case "right":
                    rotation = 1.5708f;
                    Location = Vector2.Add(Location, new Vector2(moveSpeed, 0));
                    break;
                case "down":
                    rotation = 3.14159f;
                    Location = Vector2.Add(Location, new Vector2(0, moveSpeed));
                    break;
                case "left":
                    rotation = 4.71239f;
                    Location = Vector2.Subtract(Location, new Vector2(moveSpeed, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
