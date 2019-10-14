using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class CollectableSpriteFactory
    {
        private Texture2D collectableSpriteSheet;

        private static CollectableSpriteFactory instance = new CollectableSpriteFactory();

        public static CollectableSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private CollectableSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            collectableSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
        }

        public ICollectable CreateArrowSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableArrowSprite(spriteBatch, location);
        }

        public ICollectable CreateBigHeartSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableBigHeartSprite(spriteBatch, location);
        }

        public ICollectable CreateBombSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableBombSprite(spriteBatch, location);
        }

        public ICollectable CreateBoomerangSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableBoomerangSprite(spriteBatch, location);
        }

        public ICollectable CreateBowSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableBowSprite(spriteBatch, location);
        }

        public ICollectable CreateClockSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableClockSprite(spriteBatch, location);
        }

        public ICollectable CreateCompassSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableCompassSprite(spriteBatch, location);
        }

        public ICollectable CreateFairySprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableFairySprite(spriteBatch, location);
        }

        public ICollectable CreateKeySprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableKeySprite(spriteBatch, location);
        }

        public ICollectable CreateLetterSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableLetterSprite(spriteBatch, location);
        }

        public ICollectable CreateLittleHeartSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableLittleHeartSprite(spriteBatch, location);
        }

        public ICollectable CreateMultipleRupeeSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableMultipleRupeeSprite(spriteBatch, location);
        }

        public ICollectable CreateSingleRupeeSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableSingleRupeeSprite(spriteBatch, location);
        }

        public ICollectable CreateSwordSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableSwordSprite(spriteBatch, location);
        }

        public ICollectable CreateTriforceSprite(SpriteBatch spriteBatch, Vector2 location)
        {
            return new CollectableTriforceSprite(spriteBatch, location);
        }
    }
}
