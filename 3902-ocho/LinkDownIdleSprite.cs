using Microsoft.Xna.Framework;
using System;

public class LinkDownIdleSprite
{
    public LinkDownIdleSprite()
    {
    }

    public Rectangle GetSourceRectangle()
    {
        int xPos = 1;
        int yPos = 11;
        int width = 16;
        int height = 16;

        return new Rectangle(xPos, yPos, width, height);
    }
}
