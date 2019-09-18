﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_ocho
{
    public class Texture2DStorage
    {
        private static Texture2D linkSpriteSheet;
        private static Texture2D collectableSpriteSheet;

        public Texture2DStorage()
        {
        }

        public static void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
            collectableSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
        }

        public static Texture2D GetLinkSpriteSheet()
        {
            return linkSpriteSheet;
        }

        public static Texture2D GetCollectableSpriteSheet()
        {
            return collectableSpriteSheet;
        }
    }
}
