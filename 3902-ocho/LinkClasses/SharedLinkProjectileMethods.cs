

using Microsoft.Xna.Framework;

namespace Legend_of_zelda_game.LinkClasses
{
    class SharedLinkProjectileMethods
    {
        Link link;

        public SharedLinkProjectileMethods(Link link)
        {
            this.link = link;
        }

        public bool checkLinkState()
        {
            bool okToAddProjectile = true;

            if ((link.state is LinkWoodSwordDownState || link.state is LinkWoodSwordLeftState ||
                link.state is LinkWoodSwordRightState || link.state is LinkWoodSwordUpState ||
                link.state is LinkUseItemDownState || link.state is LinkUseItemLeftState ||
                link.state is LinkUseItemRightState || link.state is LinkUseItemUpState) &&
                (link.previousState is LinkWoodSwordDownState || link.previousState is LinkWoodSwordLeftState ||
                link.previousState is LinkWoodSwordRightState || link.previousState is LinkWoodSwordUpState ||
                link.previousState is LinkUseItemDownState || link.previousState is LinkUseItemLeftState ||
                link.previousState is LinkUseItemRightState || link.previousState is LinkUseItemUpState))
            {
                okToAddProjectile = false;
            }

            return okToAddProjectile;
        }

        public string FindUseItemDirection()
        {
            string direct = "none";
            if (link.state is LinkUseItemDownState)
            {
                direct = "down";
            }
            else if (link.state is LinkUseItemUpState)
            {
                direct = "up";
            }
            else if (link.state is LinkUseItemLeftState)
            {
                direct = "left";
            }
            else if (link.state is LinkUseItemRightState)
            {
                direct = "right";
            }
            return direct;
        }
    }
}
