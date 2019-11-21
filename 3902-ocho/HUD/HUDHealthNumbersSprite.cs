using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class HUDHealthNumbersSprite : IHUD
    {
        public Link link;
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 8;
        private int height = 8;
        private int scale = 3;

        public HUDHealthNumbersSprite(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            Rectangle originalDestinationRectangleLocation = destinationRectangle;
            int totalHealth = link.HealthStateMachine.GetTotalHealth();
            int currentHealth = link.HealthStateMachine.GetHealth();
            sourceRectangle = GetFullHeartSourceRectangle();
            for (int i = 0; i < (currentHealth / 2); i++)
            {
                Draw();
                destinationRectangle.X += width * scale;
            }
            sourceRectangle = GetHalfHeartSourceRectangle();
            for (int i = 0; i < (currentHealth % 2); i++)
            {
                Draw();
                destinationRectangle.X += width * scale;
            }
            sourceRectangle = GetEmptyHeartSourceRectangle();
            for (int i = 0; i < ((totalHealth - currentHealth) / 2); i++)
            {
                Draw();
                destinationRectangle.X += width * scale;
            }
            destinationRectangle = originalDestinationRectangleLocation;
        }

        public void Draw()
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetEmptyHeartSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(627, 117, width, height);
            return rectangle;
        }

        public Rectangle GetHalfHeartSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(636, 117, width, height);
            return rectangle;
        }

        public Rectangle GetFullHeartSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(645, 117, width, height);
            return rectangle;
        }
    }
}
