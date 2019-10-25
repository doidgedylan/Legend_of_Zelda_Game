using _3902_ocho.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.GameStates
{
    public class GameOverState : IGameState
    {
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public GameOverState(SpriteBatch spriteBatch, SpriteFont font)
        {
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            spriteBatch.DrawString(font, "Game Over", new Vector2(300, 250), Color.Black);
            spriteBatch.DrawString(font, "Press R to replay, or Q to quit", new Vector2(300, 350), Color.Black);
        }
    }
}
