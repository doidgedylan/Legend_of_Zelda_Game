using _3902_ocho.Interfaces;
using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_ocho.GameStates
{
    public class GameplayState : IGameState
    {
        private Link link;
        private Game1 game;

        public GameplayState(Game1 game, Link link)
        {
            this.link = link;
            this.game = game;
        }

        public void Update()
        {
            game.CurrentRoom.Background.Draw();

            foreach (ICollectable collectable in game.CurrentRoom.Collectables)
            {
                collectable.Update();
            }

            foreach (IEnemies enemy in game.CurrentRoom.Enemies)
            {
                enemy.Update();
            }

            foreach (ISprite NPC in game.CurrentRoom.NPCs)
            {
                NPC.Update();
            }
            foreach (ISprite HUD in game.CurrentRoom.HeadsUpDisplay)
            {
                HUD.Update();
            }
            foreach (IProjectile projectile in game.CurrentRoom.LinkProjectiles)
            {
                projectile.Update();
            }

            link.LinkCollisions.Update(game.CurrentRoom.Collectables, game.CurrentRoom.Enemies, game.CurrentRoom.Blocks, game.StateManager);
            link.LinkProjectiles.Update(game.CurrentRoom.LinkProjectiles, game.CurrentRoom.Enemies, game.CurrentRoom.Blocks);
            link.Update();
        }
    }
}
