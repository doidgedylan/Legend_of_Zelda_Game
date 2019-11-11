using _3902_ocho.Interfaces;
using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho.GameStates
{
    public class ItemSelectState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        public ItemSelectState(Game1 game, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            game.ItemSelectRoom.Background.Draw();
        }
    }
}
