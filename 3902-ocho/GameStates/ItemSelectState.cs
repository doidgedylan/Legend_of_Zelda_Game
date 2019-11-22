using Legend_of_zelda_game.CollectableSprites;
using Legend_of_zelda_game.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legend_of_zelda_game.GameStates
{
    public class ItemSelectState : IGameState
    {
        private Game1 game;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        private Link link;
        public ItemSelectState(Game1 game, Link link, SpriteBatch spriteBatch, SpriteFont font)
        {
            this.game = game;
            this.link = link;
            this.font = font;
            this.spriteBatch = spriteBatch;
        }
        public void Update()
        {
            ICollectable currentItemSprite;
            foreach (IHUD HUD in game.ItemSelectRoom.HeadsUpDisplay)
            {
                HUD.Update(link);
            }
            game.ItemSelectRoom.Background.Draw();

            // location of current item box
            int x = 210;
            int y = 155 + 168;
            switch (link.currentItem)
            {
                case "arrow":
                    currentItemSprite = CollectableSpriteFactory.Instance.CreateArrowSprite(spriteBatch, new Vector2(x, y));
                    break;
                case "bomb":
                    currentItemSprite = CollectableSpriteFactory.Instance.CreateBombSprite(spriteBatch, new Vector2(x, y));
                    break;
                case "boomerang":
                    currentItemSprite = CollectableSpriteFactory.Instance.CreateBoomerangSprite(spriteBatch, new Vector2(x, y));
                    break;
                case "portals":
                    currentItemSprite = new CollectablePortalSprite(spriteBatch, new Vector2(x, y));
                    break;
                default:
                    // default to arrowSprite
                    currentItemSprite = CollectableSpriteFactory.Instance.CreateArrowSprite(spriteBatch, new Vector2(x, y));
                    break;
            }
            currentItemSprite.Draw(spriteBatch);

            foreach (ICollectable item in link.LinkItems)
            {
                ICollectable itemSprite = null;
                if (item is CollectableMapSprite)
                {
                    // location of map sprite
                    x = 150;
                    y = 350 + 168;
                    itemSprite = CollectableSpriteFactory.Instance.CreateMapSprite(spriteBatch, new Vector2(x, y));
                    // draw dungeon map here
                    //HUDMapLocation dot = new HUDMapLocation(spriteBatch, new Vector2(idk, idk), link);
                    HUDMapSprite map = new HUDMapSprite(spriteBatch, new Vector2(370, 325 + 168), link);
                    map.Update(link);
                    map.Draw();
                }
                else if (item is CollectableCompassSprite)
                {
                    // location of compass sprite
                    x = 150;
                    y = 470 + 168;
                    itemSprite = CollectableSpriteFactory.Instance.CreateCompassSprite(spriteBatch, new Vector2(x, y));
                }
                else if (item is CollectableBoomerangSprite)
                {
                    x = 420;
                    y = 160 + 168;
                    itemSprite = CollectableSpriteFactory.Instance.CreateBoomerangSprite(spriteBatch, new Vector2(x, y));
                }
                else if (item is CollectableBombSprite)
                {
                    x = 490;
                    y = 160 + 168;
                    itemSprite = CollectableSpriteFactory.Instance.CreateBombSprite(spriteBatch, new Vector2(x, y));
                }
                else if (item is CollectableArrowSprite)
                {
                    x = 560;
                    y = 160 + 168;
                    itemSprite = CollectableSpriteFactory.Instance.CreateArrowSprite(spriteBatch, new Vector2(x, y));
                }
                else if (item is CollectablePortalSprite)
                {
                    x = 630;
                    y = 160 + 168;
                    itemSprite = new CollectablePortalSprite(spriteBatch, new Vector2(x, y));
                }
                itemSprite.Draw(spriteBatch);
            }
        }
    }
}
