using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game
{
    public class Texture2DStorage
    {
        private static Texture2D linkSpriteSheet;
        private static Texture2D collectableSpriteSheet;
        private static Texture2D bossesSpriteSheet;
        private static Texture2D enemiesSpriteSheet;
        private static Texture2D goriyaSpriteSheet;
        private static Texture2D stalfosSpriteSheet;
        private static Texture2D oldManNPCSpriteSheet;
        private static Texture2D backgroundSpriteSheetBottom;
        private static Texture2D backgroundSpriteSheetTopLeft;
        private static Texture2D backgroundSpriteSheetTopRight;
        private static Texture2D sampleRoom1;
        private static Texture2D sampleRoom2;
        private static Texture2D sampleRoom3;

        public Texture2DStorage()
        {
        }

        public static void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
            collectableSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
            bossesSpriteSheet = content.Load<Texture2D>("BossesSpriteSheet");
            enemiesSpriteSheet = content.Load<Texture2D>("DungeonEnemiesSpriteSheet");
            goriyaSpriteSheet = content.Load<Texture2D>("GoriyaSpriteSheet");
            stalfosSpriteSheet = content.Load<Texture2D>("StalfosSpriteSheet");
            oldManNPCSpriteSheet = content.Load<Texture2D>("NPCOldMan");
            backgroundSpriteSheetBottom = content.Load<Texture2D>("BackgroundSpriteSheetBottom");
            backgroundSpriteSheetTopLeft = content.Load<Texture2D>("BackgroundSpriteSheetTopLeft");
            backgroundSpriteSheetTopRight = content.Load<Texture2D>("BackgroundSpriteSheetTopRight");
            sampleRoom1 = content.Load<Texture2D>("SampleRoom1");
            sampleRoom2 = content.Load<Texture2D>("SampleRoom2");
            sampleRoom3 = content.Load<Texture2D>("SampleRoom3");
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

        public static Texture2D GetEnemiesSpriteSheet()
        {
            return enemiesSpriteSheet;
        }

        public static Texture2D GetGoriyaSpriteSheet()
        {
            return goriyaSpriteSheet;
        }
        public static Texture2D GetStalfosSpriteSheet()
        {
            return stalfosSpriteSheet;
        }

        public static Texture2D GetOldManSpriteSheet()
        {
            return oldManNPCSpriteSheet;
        }

        public static Texture2D GetBackgroundSpriteSheetBottom()
        {
            return backgroundSpriteSheetBottom;
        }

        public static Texture2D GetBackgroundSpriteSheetTopLeft()
        {
            return backgroundSpriteSheetTopLeft;
        }

        public static Texture2D GetBackgroundSpriteSheetTopRight()
        {
            return backgroundSpriteSheetTopRight;
        }

        public static Texture2D GetSampleRoom1SpriteSheet()
        {
            return sampleRoom1;
        }

        public static Texture2D GetSampleRoom2SpriteSheet()
        {
            return sampleRoom2;
        }

        public static Texture2D GetSampleRoom3SpriteSheet()
        {
            return sampleRoom3;
        }

    }
}
