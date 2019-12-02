using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class GameOverState : IGameState
    {
        private Game1 game;
        private Texture2D spriteSheet;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        private int timer;
        public GameOverState(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            spriteSheet = Texture2DStorage.GetYouDiedSpriteSheet();
            this.spriteBatch = spriteBatch;
            this.font = font;
            timer = 0;
        }
        public void Update()
        {
            if (timer < 50)
            {
                timer++;
                game.CurrentRoom.Background.Draw();
            } 
            else
            {
                game.GraphicsDevice.Clear(Color.Black);
                spriteBatch.Draw(spriteSheet, new Rectangle(100, 100, 600, 250), new Rectangle(0, 0, 574, 235), Color.White);
                spriteBatch.DrawString(font, "Press R to Replay", new Vector2(250, 500), Color.White);
                spriteBatch.DrawString(font, "Press Q to Quit", new Vector2(250, 525), Color.White);
            }
        }
    }
}
