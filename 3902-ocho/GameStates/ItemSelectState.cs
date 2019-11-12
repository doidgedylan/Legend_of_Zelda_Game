using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
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
            foreach (ISprite HUD in game.ItemSelectRoom.HeadsUpDisplay)
            {
                HUD.Update();
            }
            game.ItemSelectRoom.Background.Draw();
        }
    }
}
