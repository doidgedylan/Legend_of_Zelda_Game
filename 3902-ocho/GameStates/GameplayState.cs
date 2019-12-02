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

            //Update Collectables
            foreach (ICollectable collectable in game.CurrentRoom.Collectables)
            {
                collectable.Update();
            }

            //Update Enemy Spawners
            if (game.HordeMode)
            {
                ISet<IEnemySpawner> enemySpawnersToRemove = new HashSet<IEnemySpawner>();
                foreach (IEnemySpawner enemySpawner in game.CurrentRoom.EnemySpawners)
                {
                    enemySpawner.SpawnEnemy.Update(game.CurrentRoom.Enemies);
                    enemySpawner.Update();
                    if (enemySpawner.HealthStateMachine.GetHealth() == 0)
                    {
                        RandomDrop("spawner", enemySpawner, null);
                        enemySpawnersToRemove.Add(enemySpawner);
                    }
                }
                foreach (IEnemySpawner enemySpawner in enemySpawnersToRemove)
                {
                    game.CurrentRoom.EnemySpawners.Remove(enemySpawner);
                }
            }

            //Update Enemies
            ISet<IEnemies> enemiesToRemove = new HashSet<IEnemies>();
            foreach (IEnemies enemy in game.CurrentRoom.Enemies)
            {
                enemy.EnemyCollisions.Update(game.CurrentRoom.Blocks);
                enemy.Update();
                if (enemy.HealthStateMachine.GetHealth() == 0)
                {
                    RandomDrop("enemy", null, enemy);
                    enemiesToRemove.Add(enemy);
                }
            }
            foreach (IEnemies enemy in enemiesToRemove)
            {
                game.CurrentRoom.Enemies.Remove(enemy);
            }

            //Update Enemy Projectiles
            foreach (IProjectile projectile in game.CurrentRoom.EnemyProjectiles)
            {
                projectile.Update();
            }
            EnemyProjectiles.Update(game.CurrentRoom.EnemyProjectiles, game.CurrentRoom.Enemies);

            //Update Blocks
            foreach(IBlock block in game.CurrentRoom.Blocks)
            {
                block.Update();
            }

            //Update NPCs
            foreach (ISprite NPC in game.CurrentRoom.NPCs)
            {
                NPC.Update();
            }

            //Update HUD
            foreach (IHUD HUD in game.CurrentRoom.HeadsUpDisplay)
            {
                HUD.Update(link);
            }

            //Update Link Projectiles
            foreach (IProjectile projectile in game.CurrentRoom.LinkProjectiles)
            {
                projectile.Update();
            }

            //Update Link Portals
            foreach (IProjectile portal in game.CurrentRoom.LinkPortals)
            {
                portal.Update();
            }

            //Update Link
            link.LinkCollisions.Update(game.CurrentRoom.Collectables, game.CurrentRoom.Enemies, game.CurrentRoom.EnemySpawners, game.CurrentRoom.Blocks, game.StateManager, game.HordeMode);
            link.LinkProjectiles.Update(game.CurrentRoom.LinkProjectiles, game.CurrentRoom.Enemies, game.CurrentRoom.EnemySpawners, game.HordeMode);
            link.LinkPortals.Update(game.CurrentRoom.LinkPortals, game.CurrentRoom.Blocks);
            link.Update();
        }

        public void RandomDrop(string spawnerOrEnemy, IEnemySpawner enemySpawner, IEnemies enemy)
        {
            Random random = new Random();
            int rand = random.Next(8);
            string drop = "none";

            if (rand < 4)
            {
                drop = drops[rand];
            }

            if (spawnerOrEnemy.Equals("spawner"))
            {
                switch (drop)
                {
                    case "bomb":
                        game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateBombSprite(game.spriteBatch, new Vector2(enemySpawner.LocationRect.X, enemySpawner.LocationRect.Y)));
                        break;
                    case "fairy":
                        game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateFairySprite(game.spriteBatch, new Vector2(enemySpawner.LocationRect.X, enemySpawner.LocationRect.Y)));
                        break;
                    case "little-heart":
                        game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateLittleHeartSprite(game.spriteBatch, new Vector2(enemySpawner.LocationRect.X, enemySpawner.LocationRect.Y)));
                        break;
                    case "single-rupee":
                        game.CurrentRoom.Collectables.Add(CollectableSpriteFactory.Instance.CreateSingleRupeeSprite(game.spriteBatch, new Vector2(enemySpawner.LocationRect.X, enemySpawner.LocationRect.Y)));
                        break;
                    default:
                        break;
                }
            }
            else if (spawnerOrEnemy.Equals("enemy"))
            {
                switch (drop)
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
            }
        }
    }
}
