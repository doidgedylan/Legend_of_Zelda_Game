using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Legend_of_zelda_game.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Legend_of_zelda_game.Controllers;
using Legend_of_zelda_game.Commands;
using Legend_of_zelda_game.GameStates;
using Microsoft.Xna.Framework.Media;

namespace Legend_of_zelda_game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public const int NUMBER_OF_ROOMS = 18;
        public SpriteBatch spriteBatch;
        private SpriteFont font;
        private KeyboardController gameplayKeyboardController;
        private MouseController gameplayMouseController;
        private KeyboardController titleScreenKeyboardController;
        private MouseController titleScreenMouseController;
        private Link link;
        private ISet<ICollectable> collectables;
        private ISet<IEnemies> enemies;
        private ISet<ISprite> NPCs;
        private ISet<IBlock> blocks;
        private IBackground background;
        private ISet<IHUD> headsUpDisplay;
        public IGameState CurrentState { get; set; }
        public StateManager StateManager { get; set; }
        public Room[] Rooms { get; set; }
        public Room CurrentRoom { get; set; }
        public Room ItemSelectRoom { get; set; }
        private Song bgm;

        public Game1()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += OnDeviceCreated;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 716;
            graphics.ApplyChanges();
            this.Rooms = new Room[NUMBER_OF_ROOMS];
        }

        private void OnDeviceCreated(object sender, System.EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2DStorage.LoadAllTextures(Content);
            font = Content.Load<SpriteFont>("Controls");
            CollectableSpriteFactory.Instance.LoadAllTextures(Content);

            LevelLoader Loader = new LevelLoader(spriteBatch);

            LoadAllRooms(NUMBER_OF_ROOMS);
            SelectRoom(2);
            ItemSelectRoom = new Room(0, spriteBatch);

            /* The code commented out below is the background sound. Currently, the background
             * sound does not work for some group members. The professor has been contacted and
             * a resolution cannot currently be found.
             */
            //bgm = Content.Load<Song>("OverworldSound");
            //MediaPlayer.Play(bgm);
            //MediaPlayer.IsRepeating = true;

            this.link = new Link(spriteBatch, new Vector2(390, 570));
            StateManager = new StateManager(this, spriteBatch, font, link);
            StateManager.SetTitleScreenState();

            //Set up title screen keyboard and mouse controller
            titleScreenKeyboardController = new KeyboardController();
            titleScreenMouseController = new MouseController();
            titleScreenKeyboardController.RegisterCommand(Buttons.Enter, new SwitchToGamePlayCommand(this));
            titleScreenKeyboardController.RegisterCommand(Buttons.NoButtonsPressed, new DoNothingCommand());
            titleScreenKeyboardController.RegisterCommand(Buttons.Q, new ExitCommand(this));
            titleScreenKeyboardController.RegisterCommand(Buttons.R, new DoNothingCommand());
            titleScreenMouseController.RegisterCommand(Buttons.LeftClick, new SwitchToGamePlayCommand(this));
            titleScreenMouseController.RegisterCommand(Buttons.RightClick, new DoNothingCommand());

            //Set up gameplay keyboard and mouse controller
            gameplayKeyboardController = new KeyboardController();
            gameplayMouseController = new MouseController();
            gameplayKeyboardController.RegisterCommand(Buttons.Enter, new DoNothingCommand());
            gameplayKeyboardController.RegisterCommand(Buttons.Q, new ExitCommand(this));
            gameplayKeyboardController.RegisterCommand(Buttons.W, new LinkMoveUpCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.A, new LinkMoveLeftCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.S, new LinkMoveDownCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.D, new LinkMoveRightCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.Up, new LinkMoveUpCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.Left, new LinkMoveLeftCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.Down, new LinkMoveDownCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.Right, new LinkMoveRightCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.NoButtonsPressed, new LinkStopCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.Z, new LinkWoodSwordCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.N, new LinkWoodSwordCommand(link));
            gameplayMouseController.RegisterCommand(Buttons.LeftClick, new LinkWoodSwordCommand(link));
            gameplayMouseController.RegisterCommand(Buttons.RightClick, new LinkUseItemCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.X, new LinkUseItemCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.C, new LinkSwitchItemCommand(link));
            gameplayKeyboardController.RegisterCommand(Buttons.R, new ResetCommand(this));
            gameplayKeyboardController.RegisterCommand(Buttons.B, new PauseCommand(this));
            gameplayKeyboardController.RegisterCommand(Buttons.G, new UnpauseCommand(this));
            gameplayKeyboardController.RegisterCommand(Buttons.D1, new LoadRoomCommand(this, 1));
            gameplayKeyboardController.RegisterCommand(Buttons.D2, new LoadRoomCommand(this, 2));
            gameplayKeyboardController.RegisterCommand(Buttons.D3, new LoadRoomCommand(this, 3));
            gameplayKeyboardController.RegisterCommand(Buttons.D4, new LoadRoomCommand(this, 4));
            gameplayKeyboardController.RegisterCommand(Buttons.D5, new LoadRoomCommand(this, 5));
            gameplayKeyboardController.RegisterCommand(Buttons.D6, new LoadRoomCommand(this, 6));
            gameplayKeyboardController.RegisterCommand(Buttons.D7, new LoadRoomCommand(this, 7));
            gameplayKeyboardController.RegisterCommand(Buttons.D8, new LoadRoomCommand(this, 8));
            gameplayKeyboardController.RegisterCommand(Buttons.D9, new LoadRoomCommand(this, 9));
            gameplayKeyboardController.RegisterCommand(Buttons.D0, new LoadRoomCommand(this, 10));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad1, new LoadRoomCommand(this, 11));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad2, new LoadRoomCommand(this, 12));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad3, new LoadRoomCommand(this, 13));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad4, new LoadRoomCommand(this, 14));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad5, new LoadRoomCommand(this, 15));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad6, new LoadRoomCommand(this, 16));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad7, new LoadRoomCommand(this, 17));
            gameplayKeyboardController.RegisterCommand(Buttons.NumPad8, new LoadRoomCommand(this, 18));
        }

        private void LoadAllRooms(int numberOfRooms)
        {
            for (int i = 1; i <= numberOfRooms; i++)
            {
                Rooms[i - 1] = new Room(i, spriteBatch);
            }
        }

        public void SelectRoom(int destinationRoomNumber)
        {
            CurrentRoom = Rooms[destinationRoomNumber - 1];
        }

        public void LoadRoomContent(int roomNumber)
        {
            FileStream LevelFile = new FileStream("Room" + roomNumber + "File.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlReader Reader = XmlReader.Create(LevelFile);
            LevelLoader Loader = new LevelLoader(spriteBatch);
            Loader.Load(LevelFile, Reader);

            this.collectables = Loader.Collectables;
            this.enemies = Loader.Enemies;
            this.background = Loader.Background;
            this.blocks = Loader.Blocks;
            this.NPCs = Loader.NPCs;
            this.headsUpDisplay = Loader.HUD;
        }

        public void ReloadContent()
        {
            LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (CurrentState is TitleScreenState)
            {
                titleScreenKeyboardController.Update();
                titleScreenMouseController.Update();
            }
            else if (!(link.state is LinkWoodSwordDownState) && !(link.state is LinkWoodSwordUpState) &&
                !(link.state is LinkWoodSwordLeftState) && !(link.state is LinkWoodSwordRightState) &&
                !(link.state is LinkHurtDownState) && !(link.state is LinkHurtUpState) &&
                !(link.state is LinkHurtLeftState) && !(link.state is LinkHurtRightState) &&
                !(link.state is LinkUseItemDownState) && !(link.state is LinkUseItemUpState) &&
                !(link.state is LinkUseItemLeftState) && !(link.state is LinkUseItemRightState) &&
                !(link.state is LinkPickUpItemState))
            {
                gameplayKeyboardController.Update();
                gameplayMouseController.Update();
            }

            spriteBatch.Begin();
            CurrentState.Update();
            if (link.currentItem.Equals("Triforce"))
            {
                StateManager.SetWinningState();
            }
            if (link.HealthStateMachine.GetHealth() == 0)
            {
                StateManager.SetGameOverState();
                gameplayKeyboardController.Update();
            }

            spriteBatch.End();
        }
    }
}
