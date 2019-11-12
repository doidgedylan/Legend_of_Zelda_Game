using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class GameOverState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public GameOverState(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            game.CurrentRoom.Background.Draw();
            spriteBatch.DrawString(font, "Game Over", new Vector2(300, 250), Color.Black);
            spriteBatch.DrawString(font, "Press R to replay, or Q to quit", new Vector2(300, 350), Color.Black);
        }
    }
}
