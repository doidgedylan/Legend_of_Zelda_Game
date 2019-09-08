using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0
{
    // sprites obtained from https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ISprite textSprite;
        public ISprite CurrentSprite { get; set; }
        IController keyboardController;
        IController mouseController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            keyboardController = new KeyboardController();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            int SpriteXPosition = 325;
            int SpriteYPosition = 165;
            textSprite = new TextSprite(this.Content.Load<SpriteFont>("Text"));
            Texture2D FrontFacingLinkSprite = this.Content.Load<Texture2D>("FrontFacingLinkSprite");
            Texture2D WalkingLinkSprites = this.Content.Load<Texture2D>("WalkingLinkSprites");

            ISprite StationarySprite = new StationarySprite(FrontFacingLinkSprite, SpriteXPosition, SpriteYPosition);
            ISprite MovingSprite = new MovingSprite(FrontFacingLinkSprite, SpriteXPosition, SpriteYPosition);
            ISprite AnimatedSprite = new AnimatedSprite(WalkingLinkSprites, SpriteXPosition, SpriteYPosition, 1, 2);
            ISprite MovingAnimatedSprite = new MovingAnimatedSprite(WalkingLinkSprites, SpriteXPosition, SpriteYPosition, 1, 2);

            ICommand ExitCommand = new ExitCommand(this);
            ICommand StationarySpriteCommand = new StationarySpriteCommand(this, StationarySprite);
            ICommand AnimatedSpriteCommand = new AnimatedSpriteCommand(this, AnimatedSprite);
            ICommand MovingSpriteCommand = new MovingSpriteCommand(this, MovingSprite);
            ICommand MovingAnimatedSpriteCommand = new MovingAnimatedSpriteCommand(this, MovingAnimatedSprite);

            keyboardController.RegisterCommand(Keys.D0, ExitCommand);
            keyboardController.RegisterCommand(Keys.D1, StationarySpriteCommand);
            keyboardController.RegisterCommand(Keys.D2, AnimatedSpriteCommand);
            keyboardController.RegisterCommand(Keys.D3, MovingSpriteCommand);
            keyboardController.RegisterCommand(Keys.D4, MovingAnimatedSpriteCommand);

            mouseController = new MouseController(240, 400, ExitCommand, StationarySpriteCommand, AnimatedSpriteCommand, MovingSpriteCommand, MovingAnimatedSpriteCommand);

            this.CurrentSprite = StationarySprite;

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {

            keyboardController.Update();
            mouseController.Update();
            CurrentSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            CurrentSprite.Draw(spriteBatch);
            textSprite.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
