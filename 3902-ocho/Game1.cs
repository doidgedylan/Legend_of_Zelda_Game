using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        ICollectable arrow, bomb, boomerang, bow, clock, compass, fairy, bigHeart, littleHeart;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //screenWidth = graphics.GraphicsDevice.PresentationParameters.Bounds.Width;
            //screenHeight = graphics.GraphicsDevice.PresentationParameters.Bounds.Height;
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
            link = new Link(spriteBatch);
            arrow = new CollectableArrowSprite(spriteBatch);
            bomb = new CollectableBombSprite(spriteBatch);
            boomerang = new CollectableBoomerangSprite(spriteBatch);
            bow = new CollectableBowSprite(spriteBatch);
            clock = new CollectableClockSprite(spriteBatch);
            compass = new CollectableCompassSprite(spriteBatch);
            fairy = new CollectableFairySprite(spriteBatch);
            bigHeart = new CollectableBigHeartSprite(spriteBatch);
            littleHeart = new CollectableLittleHeartSprite(spriteBatch);

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
            arrow.Update();
            bomb.Update();
            boomerang.Update();
            bow.Update();
            clock.Update();
            compass.Update();
            fairy.Update();
            bigHeart.Update();
            littleHeart.Update();
        }
    }
}
