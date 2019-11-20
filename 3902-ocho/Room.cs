using System.Collections.Generic;
using System.IO;
using System.Xml;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class Room
    {
        public int RoomNumber { get; }
        public ISet<ICollectable> Collectables { get; }
        public ISet<IEnemies> Enemies { get; }
        public ISet<ISprite> NPCs { get; }
        public ISet<IBlock> Blocks { get; }
        public IBackground Background { get; }
        public ISet<IHUD> HeadsUpDisplay { get; }
        public ISet<IProjectile> LinkProjectiles { get; }
        public ISet<IProjectile> LinkPortals { get; }
        public ISet<IProjectile> EnemyProjectiles { get; }

        public Room(int roomNumber, SpriteBatch spriteBatch)
        {
            FileStream LevelFile = new FileStream("Room" + roomNumber + "File.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlReader Reader = XmlReader.Create(LevelFile);
            LevelLoader Loader = new LevelLoader(spriteBatch);
            Loader.Load(LevelFile, Reader);

            this.Collectables = Loader.Collectables;
            this.Enemies = Loader.Enemies;
            this.Background = Loader.Background;
            this.Blocks = Loader.Blocks;
            this.NPCs = Loader.NPCs;
            this.HeadsUpDisplay = Loader.HUD;
            this.LinkProjectiles = new HashSet<IProjectile>();
            this.LinkPortals = new HashSet<IProjectile>();
            this.EnemyProjectiles = new HashSet<IProjectile>();
        }
    }
}
