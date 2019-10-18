using System.Xml;
using System.IO;
using System.Collections.Generic;
using System;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.EnemySprites;

namespace Legend_of_zelda_game
{
    public class LevelLoader
    {
        private SpriteBatch spriteBatch;
        public ISet<IBackground> Backgrounds { get; set; }
        public Link Link { get; set; }
        public ISet<IEnemies> Enemies { get; set; }
        public ISet<IBlock> Blocks { get; set; }
        public ISet<ICollectable> Collectables { get; set; }
        public ISet<INPC> NPCs { get; set; }

        public LevelLoader(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.Backgrounds = new HashSet<IBackground>();
            this.Enemies = new HashSet<IEnemies>();
            this.Blocks = new HashSet<IBlock>();
            this.Collectables = new HashSet<ICollectable>();
            this.NPCs = new HashSet<INPC>();
        }

        public void Load(FileStream input, XmlReader reader)
        {
            reader.ReadToFollowing("Item");
            while (reader.Name.Equals("Item"))
            {
                ProcessItem(input, reader);
                reader.ReadToFollowing("Item");
            }
        }

        private void ProcessItem(FileStream input, XmlReader reader)
        {
            string ObjectType = "";
            string ObjectName = "";
            string LocationStr = "";
            Vector2 Location;

            while (reader.Read() && !reader.Name.Equals("Item"))
            {
                switch (reader.Name)
                {
                    case "ObjectType":
                        reader.Read();
                        ObjectType = reader.ReadContentAsString();
                        break;
                    case "ObjectName":
                        reader.Read();
                        ObjectName = reader.ReadContentAsString();
                        break;
                    case "Location":
                        reader.Read();
                        LocationStr = reader.ReadContentAsString();
                        break;
                    default:
                        //do nothing
                        break;
                }
            }

            int X = Int32.Parse(LocationStr.Substring(0, LocationStr.IndexOf(" ")));
            int Y = Int32.Parse(LocationStr.Substring(LocationStr.IndexOf(" ") + 1));
            Location = new Vector2(X, Y);
            switch (ObjectName)
            {
                case "SampleRoom1":
                    this.Backgrounds.Add(new SampleRoom1Sprite(spriteBatch, Location));
                    break;
                case "SampleRoom2":
                    this.Backgrounds.Add(new SampleRoom2Sprite(spriteBatch, Location));
                    break;
                case "SampleRoom3":
                    this.Backgrounds.Add(new SampleRoom3Sprite(spriteBatch, Location));
                    break;
                case "BackgroundSpriteBottom":
                    this.Backgrounds.Add(new BackgroundSpriteBottom(spriteBatch, Location));
                    break;
                case "BackgroundSpriteTopLeft":
                    this.Backgrounds.Add(new BackgroundSpriteTopLeft(spriteBatch, Location));
                    break;
                case "BackgroundSpriteTopRight":
                    this.Backgrounds.Add(new BackgroundSpriteTopRight(spriteBatch, Location));
                    break;
                case "WaterBlock":
                    this.Blocks.Add(new WaterBlock(Location));
                    break;
                case "Block":
                    this.Blocks.Add(new Block(Location));
                    break;
                case "HorizontalWall":
                    this.Blocks.Add(new HorizontalWall(Location));
                    break;
                case "VerticalWall":
                    this.Blocks.Add(new VerticalWall(Location));
                    break;
                case "Arrow":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateArrowSprite(spriteBatch, Location));
                    break;
                case "BigHeart":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateBigHeartSprite(spriteBatch, Location));
                    break;
                case "Bomb":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateBombSprite(spriteBatch, Location));
                    break;
                case "Boomerang":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateBoomerangSprite(spriteBatch, Location));
                    break;
                case "Bow":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateBowSprite(spriteBatch, Location));
                    break;
                case "Clock":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateClockSprite(spriteBatch, Location));
                    break;
                case "Compass":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateCompassSprite(spriteBatch, Location));
                    break;
                case "Fairy":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateFairySprite(spriteBatch, Location));
                    break;
                case "Key":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateKeySprite(spriteBatch, Location));
                    break;
                case "Letter":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateLetterSprite(spriteBatch, Location));
                    break;
                case "LittleHeart":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateLittleHeartSprite(spriteBatch, Location));
                    break;
                case "MultipleRupee":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateMultipleRupeeSprite(spriteBatch, Location));
                    break;
                case "SingleRupee":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateSingleRupeeSprite(spriteBatch, Location));
                    break;
                case "Sword":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateSwordSprite(spriteBatch, Location));
                    break;
                case "Triforce":
                    this.Collectables.Add(CollectableSpriteFactory.Instance.CreateTriforceSprite(spriteBatch, Location));
                    break;
                case "Dragon":
                    this.Enemies.Add(new EnemiesDragonSprite(spriteBatch, Location));
                    break;
                case "Gel":
                    this.Enemies.Add(new EnemiesGelSprite(spriteBatch, Location));
                    break;
                case "Goriya":
                    this.Enemies.Add(new EnemiesGoriyaSprite(spriteBatch, Location));
                    break;
                case "Keese":
                    this.Enemies.Add(new EnemiesKeeseSprite(spriteBatch, Location));
                    break;
                case "Stalfos":
                    this.Enemies.Add(new EnemiesStalfosSprite(spriteBatch, Location));
                    break;
                case "Trap":
                    this.Enemies.Add(new EnemiesTrapSprite(spriteBatch, Location));
                    break;
                case "Wallmaster":
                    this.Enemies.Add(new EnemiesWallmasterSprite(spriteBatch, Location));
                    break;
                case "Link":
                    this.Link = new Link(spriteBatch, Location);
                    break;
                case "OldMan":
                    this.NPCs.Add(new OldManNPCSprite(spriteBatch, Location));
                    break;
                default:
                    // do nothing
                    break;
            }
        }
    }
}

