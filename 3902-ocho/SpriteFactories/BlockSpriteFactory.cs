using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_ocho
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
        }

        public IBlock CreateBlockPyramidSprite()
        {
            return new BlockPyramidSprite();
        }
    }
}