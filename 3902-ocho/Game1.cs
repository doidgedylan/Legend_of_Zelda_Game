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
        ICollectable arrow, bomb, boomerang, bow, clock, compass, fairy, bigHeart,
            littleHeart, key, letter, singleRupee, multipleRupee, sword, triforce;
        IEnemies dragon;
        IBlock pyramidBlock;
        private KeyboardController keyboardController;
        private MouseController mouseController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            keyboardController.Update();
            mouseController.Update();
        }
    }
}
