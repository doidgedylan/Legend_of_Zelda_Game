using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class HUDCommonMethods
    {
        private int width = 8;
        private int height = 8;
        public HUDCommonMethods()
        {
        }

        public int FindOnesDigit(int num)
        {
            return num % 10;
        }

        public int FindTensDigit(int num)
        {
            return num / 10;
        }

        public Rectangle GetZeroSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(528, 117, width, height);
            return rectangle;
        }

        public Rectangle GetOneSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(537, 117, width, height);
            return rectangle;
        }

        public Rectangle GetTwoSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(546, 117, width, height);
            return rectangle;
        }

        public Rectangle GetThreeSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(555, 117, width, height);
            return rectangle;
        }

        public Rectangle GetFourSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(564, 117, width, height);
            return rectangle;
        }

        public Rectangle GetFiveSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(573, 117, width, height);
            return rectangle;
        }

        public Rectangle GetSixSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(582, 117, width, height);
            return rectangle;
        }

        public Rectangle GetSevenSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(591, 117, width, height);
            return rectangle;
        }

        public Rectangle GetEightSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(600, 117, width, height);
            return rectangle;
        }

        public Rectangle GetNineSourceRectangle()
        {
            Rectangle rectangle = new Rectangle(609, 117, width, height);
            return rectangle;
        }
    }
}
