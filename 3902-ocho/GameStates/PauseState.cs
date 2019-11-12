using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class PauseState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public PauseState(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            game.CurrentRoom.Background.Draw();
            spriteBatch.DrawString(font, "Press P to unpause", new Vector2(300, 400), Color.Black);
        }
    }
}
