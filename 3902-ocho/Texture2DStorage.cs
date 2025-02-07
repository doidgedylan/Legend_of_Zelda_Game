﻿using Microsoft.Xna.Framework.Content;
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
        private static Texture2D headsUpDisplaySpriteSheet;
        private static Texture2D portalSpriteSheet;
        private static Texture2D titleScreenSpriteSheet;
        private static Texture2D lockedDoorsSpriteSheet;
        private static Texture2D enemySpawnerSpriteSheet;
        private static Texture2D youDiedSpriteSheet;
        private static Texture2D youWinSpriteSheet;

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
            headsUpDisplaySpriteSheet = content.Load<Texture2D>("HUD2");
            portalSpriteSheet = content.Load<Texture2D>("portals");
            titleScreenSpriteSheet = content.Load<Texture2D>("TitleScreenSpriteSheet");
            lockedDoorsSpriteSheet = content.Load<Texture2D>("LockedDoorsSpriteSheet");
            enemySpawnerSpriteSheet = content.Load<Texture2D>("EnemySpawnerSprite");
            youDiedSpriteSheet = content.Load<Texture2D>("YouDied");
            youWinSpriteSheet = content.Load<Texture2D>("YouWin");
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

        public static Texture2D GetHUDSpriteSheet()
        {
            return headsUpDisplaySpriteSheet;
        }
        public static Texture2D GetPortalSpriteSheet()
        {
            return portalSpriteSheet;
        }

        public static Texture2D GetTitleScreenSpriteSheet()
        {
            return titleScreenSpriteSheet;
        }

        public static Texture2D GetLockedDoorsSpriteSheet()
        {
            return lockedDoorsSpriteSheet;
        }

        public static Texture2D GetEnemySpawnerSpriteSheet()
        {
            return enemySpawnerSpriteSheet;
        }

        public static Texture2D GetYouDiedSpriteSheet()
        {
            return youDiedSpriteSheet;
        }

        public static Texture2D GetYouWinSpriteSheet()
        {
            return youWinSpriteSheet;
        }
    }
}
