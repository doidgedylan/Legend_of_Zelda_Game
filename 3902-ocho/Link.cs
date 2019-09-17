using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3902_ocho
{
    public class Link : ISprite
    {
        public ILinkState state;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet;
        //Vector2 Location { get; set; }


        public Link(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            spriteSheet = Texture2DStorage.GetLinkSpriteSheet();
            state = new LinkMoveDownState(this);
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw(Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
