using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
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

        public ICollectable CreateArrowSprite()
        {
            return new CollectableArrowSprite();
        }

        public ICollectable CreateBigHeartSprite()
        {
            return new CollectableBigHeartSprite();
        }

        public ICollectable CreateBombSprite()
        {
            return new CollectableBombSprite();
        }

        public ICollectable CreateBoomerangSprite()
        {
            return new CollectableBoomerangSprite();
        }

        public ICollectable CreateBowSprite()
        {
            return new CollectableBowSprite();
        }

        public ICollectable CreateClockSprite()
        {
            return new CollectableClockSprite();
        }

        public ICollectable CreateCompassSprite()
        {
            return new CollectableCompassSprite();
        }

        public ICollectable CreateFairySprite()
        {
            return new CollectableFairySprite();
        }

        public ICollectable CreateKeySprite()
        {
            return new CollectableKeySprite();
        }

        public ICollectable CreateLetterSprite()
        {
            return new CollectableLetterSprite();
        }

        public ICollectable CreateLittleHeartSprite()
        {
            return new CollectableLittleHeartSprite();
        }

        public ICollectable CreateMultipleRupeeSprite()
        {
            return new CollectableMultipleRupeeSprite();
        }

        public ICollectable CreateSingleRupeeSprite()
        {
            return new CollectableSingleRupeeSprite();
        }

        public ICollectable CreateSwordSprite()
        {
            return new CollectableSwordSprite();
        }

        public ICollectable CreateTriforceSprite()
        {
            return new CollectableTriforceSprite();
        }
    }
}
