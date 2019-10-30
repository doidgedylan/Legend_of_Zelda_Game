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
        private SpriteBatch spriteBatch;
        private Room[] rooms;
        private Room currentRoom;

        private void LoadAllRooms(int numberOfRooms)
        {
            for (int i = 1; i <= numberOfRooms; i++)
            {
                rooms[i - 1] = new Room(i, spriteBatch);
            }
        }

        private void SelectRoom(int destinationRoomNumber)
        {
            currentRoom = rooms[destinationRoomNumber - 1];
        }

        public GameplayState(SpriteBatch spriteBatch, Link link)
        {
            this.link = link;
            int numberOfRooms = 18;
            this.spriteBatch = spriteBatch;
            this.rooms = new Room[numberOfRooms];
            LoadAllRooms(numberOfRooms);
            SelectRoom(12);
        }

        public void Update()
        {
            foreach (IBackground background in currentRoom.Backgrounds)
            {
                background.Draw();
            }

            foreach (ICollectable collectable in currentRoom.Collectables)
            {
                collectable.Update();
            }

            foreach (IEnemies enemy in currentRoom.Enemies)
            {
                enemy.Update();
            }

            foreach (ISprite NPC in currentRoom.NPCs)
            {
                NPC.Update();
            }
            foreach (ISprite HUD in currentRoom.HeadsUpDisplay)
            {
                HUD.Update();
            }
            foreach (IProjectile projectile in currentRoom.LinkProjectiles)
            {
                projectile.Update();
            }

            link.LinkCollisions.Update(currentRoom.Collectables, currentRoom.Enemies, currentRoom.Blocks);
            link.LinkProjectiles.Update(currentRoom.LinkProjectiles, currentRoom.Enemies, currentRoom.Blocks);
            link.Update();
        }
    }
}
