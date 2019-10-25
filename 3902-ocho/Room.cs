using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_ocho
{
    public class Room
    {
        public int RoomNumber { get; }
        public ISet<ICollectable> Collectables { get; }
        public ISet<IEnemies> Enemies { get; }
        public ISet<INPC> NPCs { get; }
        public ISet<IBlock> Blocks { get; }
        public ISet<IBackground> Backgrounds { get; }

        public Room(int roomNumber, SpriteBatch spriteBatch)
        {
            FileStream LevelFile = new FileStream("Room" + roomNumber + "File.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlReader Reader = XmlReader.Create(LevelFile);
            LevelLoader Loader = new LevelLoader(spriteBatch);
            Loader.Load(LevelFile, Reader);

            this.Collectables = Loader.Collectables;
            this.Enemies = Loader.Enemies;
            this.Backgrounds = Loader.Backgrounds;
            this.Blocks = Loader.Blocks;
            this.NPCs = Loader.NPCs;
        }
    }
}
