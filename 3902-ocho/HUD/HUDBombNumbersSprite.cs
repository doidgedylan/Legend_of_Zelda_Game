using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class HUDBombNumbersSprite : IHUD
    {
        public Link link;
        private HUDCommonMethods hudMethods = new HUDCommonMethods();
        public Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int width = 8;
        private int height = 8;
        private int scale = 3;

        public HUDBombNumbersSprite(SpriteBatch spriteBatch, Vector2 location, Link link)
        {
            this.spriteSheet = Texture2DStorage.GetHUDSpriteSheet();
            this.spriteBatch = spriteBatch;
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            this.link = link;
        }

        public void Update(Link link)
        {
            int tensDigit = hudMethods.FindTensDigit(link.numBombs);
            switch (tensDigit)
            {
                case 0:
                    sourceRectangle = hudMethods.GetZeroSourceRectangle();
                    break;
                case 1:
                    sourceRectangle = hudMethods.GetOneSourceRectangle();
                    break;
                case 2:
                    sourceRectangle = hudMethods.GetTwoSourceRectangle();
                    break;
                case 3:
                    sourceRectangle = hudMethods.GetThreeSourceRectangle();
                    break;
                case 4:
                    sourceRectangle = hudMethods.GetFourSourceRectangle();
                    break;
                case 5:
                    sourceRectangle = hudMethods.GetFiveSourceRectangle();
                    break;
                case 6:
                    sourceRectangle = hudMethods.GetSixSourceRectangle();
                    break;
                case 7:
                    sourceRectangle = hudMethods.GetSevenSourceRectangle();
                    break;
                case 8:
                    sourceRectangle = hudMethods.GetEightSourceRectangle();
                    break;
                case 9:
                    sourceRectangle = hudMethods.GetNineSourceRectangle();
                    break;
                default:
                    break;
            }
            Draw();
            int onesDigit = hudMethods.FindOnesDigit(link.numBombs);
            switch (onesDigit)
            {
                case 0:
                    sourceRectangle = hudMethods.GetZeroSourceRectangle();
                    break;
                case 1:
                    sourceRectangle = hudMethods.GetOneSourceRectangle();
                    break;
                case 2:
                    sourceRectangle = hudMethods.GetTwoSourceRectangle();
                    break;
                case 3:
                    sourceRectangle = hudMethods.GetThreeSourceRectangle();
                    break;
                case 4:
                    sourceRectangle = hudMethods.GetFourSourceRectangle();
                    break;
                case 5:
                    sourceRectangle = hudMethods.GetFiveSourceRectangle();
                    break;
                case 6:
                    sourceRectangle = hudMethods.GetSixSourceRectangle();
                    break;
                case 7:
                    sourceRectangle = hudMethods.GetSevenSourceRectangle();
                    break;
                case 8:
                    sourceRectangle = hudMethods.GetEightSourceRectangle();
                    break;
                case 9:
                    sourceRectangle = hudMethods.GetNineSourceRectangle();
                    break;
                default:
                    break;
            }
            destinationRectangle.X += width * scale;
            Draw();
            destinationRectangle.X -= width * scale;
        }

        public void Draw()
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
