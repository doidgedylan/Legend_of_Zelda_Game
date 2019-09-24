using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_ocho
{
    public class Texture2DStorage
    {
        private static Texture2D linkSpriteSheet;
        private static Texture2D collectableSpriteSheet;
        private static Texture2D bossesSpriteSheet;
        private static Texture2D blockSpriteSheet;
        private static Texture2D enemiesSpriteSheet;

        public Texture2DStorage()
        {
        }

        public static void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
            collectableSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
            bossesSpriteSheet = content.Load<Texture2D>("BossesSpriteSheet");
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet");
            enemiesSpriteSheet = content.Load<Texture2D>("DungeonEnemiesSpriteSheet");
        }

        public static Texture2D GetLinkSpriteSheet()
        {
            return linkSpriteSheet;
        }

        public static Texture2D GetCollectableSpriteSheet()
        {
            return collectableSpriteSheet;
        }

        public static Texture2D GetBossesSpriteSheet()
        {
            return bossesSpriteSheet;
        }

        public static Texture2D GetBlockSpriteSheet()
        {
            return blockSpriteSheet;
        }

        public static Texture2D GetEnemiesSpriteSheet()
        {
            return enemiesSpriteSheet;
        }

    }
}
