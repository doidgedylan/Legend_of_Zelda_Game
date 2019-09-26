using _3902_ocho.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Input;

namespace _3902_ocho
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int screenWidth;
        public int screenHeight;
        Link link;
        public ICollectable arrow, bomb, boomerang, bow, clock, compass, fairy, bigHeart,
            littleHeart, key, letter, singleRupee, multipleRupee, sword, triforce;
        public IEnemies dragon, gel, keese, wallmaster, trap, goriya, stalfos;
        public IBlock pyramidBlock;
        private KeyboardController keyboardController;
        private MouseController mouseController;

        public Game1()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += OnDeviceCreated;
            Content.RootDirectory = "Content";
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
            CollectableSpriteFactory.Instance.LoadAllTextures(Content);
            link = new Link(spriteBatch);
            arrow = CollectableSpriteFactory.Instance.CreateArrowSprite();
            bomb = CollectableSpriteFactory.Instance.CreateBombSprite();
            boomerang = CollectableSpriteFactory.Instance.CreateBoomerangSprite();
            bow = CollectableSpriteFactory.Instance.CreateBowSprite();
            clock = CollectableSpriteFactory.Instance.CreateClockSprite();
            compass = CollectableSpriteFactory.Instance.CreateCompassSprite();
            fairy = CollectableSpriteFactory.Instance.CreateFairySprite();
            bigHeart = CollectableSpriteFactory.Instance.CreateBigHeartSprite();
            littleHeart = CollectableSpriteFactory.Instance.CreateLittleHeartSprite();
            key = CollectableSpriteFactory.Instance.CreateKeySprite();
            letter = CollectableSpriteFactory.Instance.CreateLetterSprite();
            singleRupee = CollectableSpriteFactory.Instance.CreateSingleRupeeSprite();
            multipleRupee = CollectableSpriteFactory.Instance.CreateMultipleRupeeSprite();
            sword = CollectableSpriteFactory.Instance.CreateSwordSprite();
            triforce = CollectableSpriteFactory.Instance.CreateTriforceSprite();

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            pyramidBlock = BlockSpriteFactory.Instance.CreateBlockPyramidSprite();

            dragon = new EnemiesDragonSprite(spriteBatch);
            gel = new EnemiesGelSprite(spriteBatch);
            keese = new EnemiesKeeseSprite(spriteBatch);
            wallmaster = new EnemiesWallmasterSprite(spriteBatch);
            trap = new EnemiesTrapSprite(spriteBatch);
            goriya = new EnemiesGoriyaSprite(spriteBatch);
            stalfos = new EnemiesStalfosSprite(spriteBatch);

            HealthStateMachine healthStateMachine = new HealthStateMachine();

            keyboardController = new KeyboardController();
            mouseController = new MouseController();
            keyboardController.RegisterCommand(Buttons.Q, new ExitCommand(this));
            keyboardController.RegisterCommand(Buttons.W, new LinkMoveUpCommand(link));
            keyboardController.RegisterCommand(Buttons.A, new LinkMoveLeftCommand(link));
            keyboardController.RegisterCommand(Buttons.S, new LinkMoveDownCommand(link));
            keyboardController.RegisterCommand(Buttons.D, new LinkMoveRightCommand(link));
            keyboardController.RegisterCommand(Buttons.Up, new LinkMoveUpCommand(link));
            keyboardController.RegisterCommand(Buttons.Left, new LinkMoveLeftCommand(link));
            keyboardController.RegisterCommand(Buttons.Down, new LinkMoveDownCommand(link));
            keyboardController.RegisterCommand(Buttons.Right, new LinkMoveRightCommand(link));
            keyboardController.RegisterCommand(Buttons.NoButtonsPressed, new LinkStopCommand(link));
            keyboardController.RegisterCommand(Buttons.E, new HurtLinkCommand(healthStateMachine));
            keyboardController.RegisterCommand(Buttons.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Buttons.T, new DrawBlocksCommand(this, spriteBatch));
            keyboardController.RegisterCommand(Buttons.Y, new DrawCollectablesCommand(this, spriteBatch));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GraphicsDevice.Clear(Color.White);

            link.Update();
            fairy.Update();
            littleHeart.Update();
            key.Update();
            letter.Update();
            singleRupee.Update();
            multipleRupee.Update();
            sword.Update();
            triforce.Update();

            dragon.Update();
            gel.Update();
            keese.Update();
            wallmaster.Update();
            trap.Update();
            goriya.Update();
            stalfos.Update();

            keyboardController.Update();
            mouseController.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            pyramidBlock.Draw(spriteBatch, new Vector2(40, 30));
            bomb.Draw(spriteBatch, new Vector2(80, 50));
            boomerang.Draw(spriteBatch, new Vector2(120, 50));
            bow.Draw(spriteBatch, new Vector2(160, 50));
            clock.Draw(spriteBatch, new Vector2(200, 50));
            compass.Draw(spriteBatch, new Vector2(240, 50));
            fairy.Draw(spriteBatch, new Vector2(280, 50));
            bigHeart.Draw(spriteBatch, new Vector2(320, 50));
            littleHeart.Draw(spriteBatch, new Vector2(360, 50));
            key.Draw(spriteBatch, new Vector2(400, 50));
            letter.Draw(spriteBatch, new Vector2(440, 50));
            singleRupee.Draw(spriteBatch, new Vector2(480, 50));
            multipleRupee.Draw(spriteBatch, new Vector2(520, 50));
            sword.Draw(spriteBatch, new Vector2(560, 50));
            triforce.Draw(spriteBatch, new Vector2(600, 50));
            arrow.Draw(spriteBatch, new Vector2(640, 50));
        }
    }
}
