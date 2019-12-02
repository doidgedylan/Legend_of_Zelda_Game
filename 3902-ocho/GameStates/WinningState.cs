using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class WinningState : IGameState
    {
        private Game1 game;
        private Link link;
        private Texture2D spriteSheet;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private int timer;

        public WinningState(Game1 game, Link link, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.link = link;
            spriteSheet = Texture2DStorage.GetYouWinSpriteSheet();
            this.font = font;
            this.spriteBatch = spriteBatch;
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
                spriteBatch.Draw(spriteSheet, new Rectangle(100, 100, 600, 250), new Rectangle(160, 120, 290, 50), Color.White);
                spriteBatch.DrawString(font, "Press R to Replay", new Vector2(250, 600), Color.White);
                spriteBatch.DrawString(font, "Press Q to Quit", new Vector2(250, 625), Color.White);
            }

            link.state = new LinkWinState(link);
            link.Update();
        }
    }
}
