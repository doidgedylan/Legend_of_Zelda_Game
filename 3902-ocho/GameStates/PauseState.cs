using _3902_ocho.Interfaces;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.GameStates
{
    public class PauseState : IGameState
    {
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public PauseState(SpriteBatch spriteBatch, SpriteFont font)
        {
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            spriteBatch.DrawString(font, "Press P to unpause", new Vector2(300, 250), Color.Black);
        }
    }
}
