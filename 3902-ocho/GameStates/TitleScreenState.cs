using Legend_of_zelda_game.EnemySprites;
using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.TitleScreen;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Legend_of_zelda_game.GameStates
{
    public class TitleScreenState : IGameState
    {
        private Game1 game;
        private ISet<ITitleScreen> titleScreenElements;
        private int currentFrame = 0;
        private int totalFrames = 10;

        public TitleScreenState(Game1 game)
        {
            this.game = game;
            titleScreenElements = new HashSet<ITitleScreen>();
            titleScreenElements.Add(new TitleScreenBackgroundSprite(this.game.spriteBatch));
            titleScreenElements.Add(new TitleScreenWaterFallSpraySprite(this.game.spriteBatch));
            titleScreenElements.Add(new TitleScreenWaterFallFoamSprite(this.game.spriteBatch));
        }

        public void Update()
        {
            ISet<ITitleScreen> titleSreenElementsToRemove = new HashSet<ITitleScreen>();
            foreach (ITitleScreen titleScreenElement in titleScreenElements)
            {
                titleScreenElement.Update();
                if (titleScreenElement is TitleScreenWaterFallFoamSprite && titleScreenElement.Location.Y > 716)
                {
                    titleSreenElementsToRemove.Add(titleScreenElement);
                }
            }
            foreach (ITitleScreen titleScreenElement in titleSreenElementsToRemove)
            {
                titleScreenElements.Remove(titleScreenElement);
            }

            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                titleScreenElements.Add(new TitleScreenWaterFallFoamSprite(game.spriteBatch));
            }
        }
    }
}
