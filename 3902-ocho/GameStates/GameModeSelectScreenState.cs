using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class GameModeSelectScreenState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private Color normalColor = Color.White;
        private Color hordeColor = Color.Gray;

        public GameModeSelectScreenState(Game1 game)
        {
            this.game = game;
            this.font = game.Content.Load<SpriteFont>("GameModeSelectScreenFont");
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.spriteBatch.DrawString(font, "Normal Mode", new Vector2(250, 250), normalColor);
            game.spriteBatch.DrawString(font, "Horde Mode", new Vector2(250, 350), hordeColor);
        }

        public void SwitchNormalAndHordeMode()
        {
            if(normalColor.Equals(Color.White))
            {
                normalColor = Color.Gray;
                hordeColor = Color.White;
                game.HordeMode = true;
            }
            else
            {
                normalColor = Color.White;
                hordeColor = Color.Gray;
                game.HordeMode = false;
            }
        }
    }
}
