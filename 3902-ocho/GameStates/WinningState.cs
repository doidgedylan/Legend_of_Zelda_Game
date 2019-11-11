using _3902_ocho.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.GameStates
{
    public class WinningState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public WinningState(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            game.CurrentRoom.Background.Draw();
            spriteBatch.DrawString(font, "You Win!!!", new Vector2(300, 250), Color.Black);
            spriteBatch.DrawString(font, "Press R to replay, or Q to quit", new Vector2(300, 350), Color.Black);
        }
    }
}
