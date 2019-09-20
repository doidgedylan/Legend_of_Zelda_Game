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
        ICollectable arrow, bigHeart, bomb, boomerang, bow, clock, compass, fairy, key,
            letter, littleHeart, multipleRupee, singleRupee, sword, triforce;

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
            CollectableSpriteFactory.Instance.LoadAllTextures(Content);
            link = new Link(spriteBatch);
            arrow = CollectableSpriteFactory.Instance.CreateArrowSprite();
            bigHeart = CollectableSpriteFactory.Instance.CreateBigHeartSprite();
            bomb = CollectableSpriteFactory.Instance.CreateBombSprite();
            boomerang = CollectableSpriteFactory.Instance.CreateBoomerangSprite();
            bow = CollectableSpriteFactory.Instance.CreateBowSprite();
            clock = CollectableSpriteFactory.Instance.CreateClockSprite();
            compass = CollectableSpriteFactory.Instance.CreateCompassSprite();
            fairy = CollectableSpriteFactory.Instance.CreateFairySprite();
            key = CollectableSpriteFactory.Instance.CreateKeySprite();
            letter = CollectableSpriteFactory.Instance.CreateLetterSprite();
            littleHeart = CollectableSpriteFactory.Instance.CreateLittleHeartSprite();
            multipleRupee = CollectableSpriteFactory.Instance.CreateMultipleRupeeSprite();
            singleRupee = CollectableSpriteFactory.Instance.CreateSingleRupeeSprite();
            sword = CollectableSpriteFactory.Instance.CreateSwordSprite();
            triforce = CollectableSpriteFactory.Instance.CreateTriforceSprite();

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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            arrow.Draw(spriteBatch, new Vector2(200, 200));
            bigHeart.Draw(spriteBatch, new Vector2(230, 200));
            bomb.Draw(spriteBatch, new Vector2(270, 200));
            boomerang.Draw(spriteBatch, new Vector2(310, 200));
            bow.Draw(spriteBatch, new Vector2(340, 200));
            clock.Draw(spriteBatch, new Vector2(200, 260));
            compass.Draw(spriteBatch, new Vector2(240, 260));
            fairy.Draw(spriteBatch, new Vector2(280, 260));
            key.Draw(spriteBatch, new Vector2(310, 260));
            letter.Draw(spriteBatch, new Vector2(340, 260));
            littleHeart.Draw(spriteBatch, new Vector2(200, 320));
            multipleRupee.Draw(spriteBatch, new Vector2(230, 320));
            singleRupee.Draw(spriteBatch, new Vector2(260, 320));
            sword.Draw(spriteBatch, new Vector2(290, 320));
            triforce.Draw(spriteBatch, new Vector2(330, 320));

            base.Draw(gameTime);
        }
    }
}
