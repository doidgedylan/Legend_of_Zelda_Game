using System.Xml;
using System.IO;
using System.Collections.Generic;
using System;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Legend_of_zelda_game.Blocks;
using Legend_of_zelda_game.EnemySprites;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game
{
    public class LevelLoader
    {
        private readonly SpriteBatch spriteBatch;
        private readonly Texture2D BackgroundBottomSpriteSheet;
        private readonly Texture2D BackgroundTopLeftSpriteSheet;
        private readonly Texture2D BackgroundTopRightSpriteSheet;
        public ISet<IBackground> Backgrounds { get; set; }
        public IBackground Background { get; set; }
        public Link Link { get; set; }
        public ISet<IEnemies> Enemies { get; set; }
        public ISet<IBlock> Blocks { get; set; }
        public ISet<ICollectable> Collectables { get; set; }
        public ISet<ISprite> NPCs { get; set; }
        public ISet<IHUD> HUD { get; set; }

        public LevelLoader(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.Backgrounds = new HashSet<IBackground>();
            this.Enemies = new HashSet<IEnemies>();
            this.Blocks = new HashSet<IBlock>();
            this.Collectables = new HashSet<ICollectable>();
            this.NPCs = new HashSet<ISprite>();
            this.HUD = new HashSet<IHUD>();
            BackgroundBottomSpriteSheet = Texture2DStorage.GetBackgroundSpriteSheetBottom();
            BackgroundTopLeftSpriteSheet = Texture2DStorage.GetBackgroundSpriteSheetTopLeft();
            BackgroundTopRightSpriteSheet = Texture2DStorage.GetBackgroundSpriteSheetTopRight();
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
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string ObjectName = "";
            string LocationStr = "";
            string DestRoomNumberStr = "";
            string DirectionStr = "";
            string LockedStr = "";
            Vector2 Location;

            while (reader.Read() && !reader.Name.Equals("Item"))
            {
                switch (reader.Name)
                {
                    case "ObjectName":
                        reader.Read();
                        ObjectName = reader.ReadContentAsString();
                        break;
                    case "Location":
                        reader.Read();
                        LocationStr = reader.ReadContentAsString();
                        break;
                    case "DestinationRoomNumber":
                        reader.Read();
                        DestRoomNumberStr = reader.ReadContentAsString();
                        break;
                    case "Direction":
                        reader.Read();
                        DirectionStr = reader.ReadContentAsString();
                        break;
                    case "Locked":
                        reader.Read();
                        LockedStr = reader.ReadContentAsString();
                        break;
                    default:
                        //do nothing
                        break;
                }
            }

            int X = Int32.Parse(LocationStr.Substring(0, LocationStr.IndexOf(" ")));
            int Y = 168 + Int32.Parse(LocationStr.Substring(LocationStr.IndexOf(" ") + 1));
            Location = new Vector2(X, Y);
            if (ObjectName.Contains("Room"))
            {
                Location = new Vector2(Location.X, Location.Y - 168);
                int roomNum = Int32.Parse(ObjectName.Substring(4));
                if (roomNum < 8) 
                {
                    this.Background = new RoomSprite(spriteBatch, Location, BackgroundBottomSpriteSheet);
                }
                else if ((roomNum >= 8 && roomNum < 11) || roomNum == 13 || (roomNum > 15 && roomNum < 19))
                {
                    this.Background = new RoomSprite(spriteBatch, Location, BackgroundTopLeftSpriteSheet);
                }
                else if ((roomNum > 10 && roomNum < 16) || roomNum != 13)
                {
                    this.Background = new RoomSprite(spriteBatch, Location, BackgroundTopRightSpriteSheet);
                }
            }
            else if (ObjectName.Contains("Door"))
            {
                int DestRoomNumber = Int32.Parse(DestRoomNumberStr);
                Direction direction = (Direction)Enum.Parse(typeof(Direction), DirectionStr);
                bool locked = Boolean.Parse(LockedStr);
                this.Blocks.Add(new Door(Location, DestRoomNumber, direction));
                if (locked)
                {
                    this.Blocks.Add(new LockedDoor(Location, direction, spriteBatch));
                }
            }
            else
            {
                switch (ObjectName)
                {
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
                    case "Map":
                        this.Collectables.Add(CollectableSpriteFactory.Instance.CreateMapSprite(spriteBatch, Location));
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
                        //this.Link = new Link(spriteBatch, Location);
                        //this.Link.Location = Location;
                        break;
                    case "OldMan":
                        this.NPCs.Add(new OldManNPCSprite(spriteBatch, Location));
                        break;
                    case "HUDLevel":
                        this.HUD.Add(new HUDLevelSprite(spriteBatch, Location));
                        break;
                    case "HUDLevelNumber":
                        this.HUD.Add(new HUDLevelNumberSprite(spriteBatch, Location));
                        break;
                    case "HUDBackground":
                        this.HUD.Add(new HUDBackgroundSprite(spriteBatch, Location));
                        break;
                    case "HUDXSymbol":
                        this.HUD.Add(new HUDXSymbolSprite(spriteBatch, Location));
                        break;
                    case "HUDKeyNumbers":
                        this.HUD.Add(new HUDKeyNumbersSprite(spriteBatch, Location, Link));
                        break;
                    case "HUDGemNumbers":
                        this.HUD.Add(new HUDGemNumbersSprite(spriteBatch, Location, Link));
                        break;
                    case "HUDBombNumbers":
                        this.HUD.Add(new HUDBombNumbersSprite(spriteBatch, Location, Link));
                        break;
                    case "HUDHealth":
                        this.HUD.Add(new HUDHealthNumbersSprite(spriteBatch, Location, Link));
                        break;
                    case "HUDMap":
                        this.HUD.Add(new HUDMapSprite(spriteBatch, Location, Link));
                        break;
                    case "HUDMapLocation":
                        this.HUD.Add(new HUDMapLocation(spriteBatch, Location, Link));
                        break;
                    case "HUDCompassLocation":
                        this.HUD.Add(new HUDCompassLocation(spriteBatch, Location, Link));
                        break;
                    case "HUDLevelBlankBackground":
                        this.HUD.Add(new HUDLevelBlankBackgroundSprite(spriteBatch, Location));
                        break;
                    case "HUDLifeBlankBackground":
                        this.HUD.Add(new HUDLifeBlankBackgroundSprite(spriteBatch, Location));
                        break;
                    case "HUDTopMap":
                        this.HUD.Add(new HUDTopMapSprite(spriteBatch, Location));
                        break;
                    case "HUDBottomMap":
                        this.HUD.Add(new HUDBottomMapSprite(spriteBatch, Location));
                        break;
                    case "HUDTopAndBottomMap":
                        this.HUD.Add(new HUDTopAndBottomMapSprite(spriteBatch, Location));
                        break;
                    case "HUDWoodSword":
                        this.HUD.Add(new HUDWoodSwordSprite(spriteBatch, Location));
                        break;
                    case "HUDArrow":
                        this.HUD.Add(new HUDArrowSprite(spriteBatch, Location));
                        break;
                    default:
                        // do nothing
                        break;
                }
            }
        }
    }
}

