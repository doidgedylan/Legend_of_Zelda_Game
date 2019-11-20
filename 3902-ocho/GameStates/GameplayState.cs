using Legend_of_zelda_game.EnemySprites;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Legend_of_zelda_game.GameStates
{
    public class GameplayState : IGameState
    {
        private Link link;
        private Game1 game;
        private EnemyProjectiles EnemyProjectiles;
        private string[] drops = new string[4] { "bomb", "fairy", "little-heart", "single-rupee" };

        public GameplayState(Game1 game, Link link)
        {
            this.link = link;
            this.game = game;
            EnemyProjectiles = new EnemyProjectiles(link);
        }

        public void Update()
        {
            game.CurrentRoom.Background.Draw();

            foreach (ICollectable collectable in game.CurrentRoom.Collectables)
            {
                collectable.Update();
            }

            ISet<IEnemies> enemiesToRemove = new HashSet<IEnemies>();
            foreach (IEnemies enemy in game.CurrentRoom.Enemies)
            {
                enemy.EnemyCollisions.Update(game.CurrentRoom.Blocks);
                enemy.Update();
                if (enemy.HealthStateMachine.GetHealth() == 0)
                {
                    switch (RandomDrop())
                    {
                        case "bomb":
                            game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateBombSprite(game.spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y)));
                            break;
                        case "fairy":
                            game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateFairySprite(game.spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y)));
                            break;
                        case "little-heart":
                            game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateLittleHeartSprite(game.spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y)));
                            break;
                        case "single-rupee":
                            game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateSingleRupeeSprite(game.spriteBatch, new Vector2(enemy.LocationRect.X, enemy.LocationRect.Y)));
                            break;
                        default:
                            break;
                    }
                    enemiesToRemove.Add(enemy);
                }
            }
            foreach (IEnemies enemy in enemiesToRemove)
            {
                game.CurrentRoom.Enemies.Remove(enemy);
            }
            foreach (IProjectile projectile in game.CurrentRoom.LinkProjectiles)
            {
                projectile.Update();
            }
            EnemyProjectiles.Update(game.CurrentRoom.LinkProjectiles, game.CurrentRoom.Enemies);


            foreach (ISprite NPC in game.CurrentRoom.NPCs)
            {
                NPC.Update();
            }
            foreach (IHUD HUD in game.CurrentRoom.HeadsUpDisplay)
            {
                HUD.Update(link);
            }
            foreach (IProjectile projectile in game.CurrentRoom.LinkProjectiles)
            {
                projectile.Update();
            }
            foreach (IProjectile portal in game.CurrentRoom.LinkPortals)
            {
                portal.Update();
            }

            link.LinkCollisions.Update(game.CurrentRoom.Collectables, game.CurrentRoom.Enemies, game.CurrentRoom.Blocks, game.StateManager);
            link.LinkProjectiles.Update(game.CurrentRoom.LinkProjectiles, game.CurrentRoom.Enemies);
            link.LinkPortals.Update(game.CurrentRoom.LinkPortals, game.CurrentRoom.Blocks);
            link.Update();
        }

        public string RandomDrop()
        {
            Random random = new Random();
            int rand = random.Next(8);
            string drop = "none";

            if (rand < 4)
            {
                drop = drops[rand];
            }

            return drop;
        }
    }
}
