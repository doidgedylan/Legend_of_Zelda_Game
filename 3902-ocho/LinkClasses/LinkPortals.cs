

using Legend_of_zelda_game.Interfaces;
using Legend_of_zelda_game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Legend_of_zelda_game.LinkClasses
{
    public class LinkPortals
    {
        private Link link;
        private SpriteBatch spriteBatch;
        private SharedLinkProjectileMethods SharedLinkProjectileMethods;
        private SharedProjectileMethods SharedProjectileMethods;
        private bool bluePortalDeployed;
        private bool redPortalDeployed;
        private string portalCollision;
        private Vector2 bluePortalLocation;
        private Vector2 redPortalLocation;

        public LinkPortals(Link link)
        {
            this.link = link;
            this.spriteBatch = link.spriteBatch;
            SharedLinkProjectileMethods = new SharedLinkProjectileMethods(this.link);
            SharedProjectileMethods = new SharedProjectileMethods();
            bluePortalDeployed = false;
            redPortalDeployed = false;
            portalCollision = "none";
            bluePortalLocation = new Vector2(this.link.Location.X, this.link.Location.Y);
            redPortalLocation = new Vector2(this.link.Location.X, this.link.Location.Y);
        }

        public void Update(ISet<IProjectile> portals, ISet<IBlock> blocks)
        {
            if (link.currentItem.Equals("portals") && SharedLinkProjectileMethods.checkLinkState())
            {
                AddPortals(portals);
            }

            ISet<IProjectile> portalsToRemove = new HashSet<IProjectile>();
            foreach (IProjectile portal in portals)
            {
                //Check if portal hit wall
                if (SharedProjectileMethods.LocationOutOfBounds(portal.Location))
                {
                    portalsToRemove.Add(portal);
                    if (portal is BluePortalProjectile)
                        bluePortalDeployed = false;
                    if (portal is RedPortalProjectile)
                        redPortalDeployed = false;
                }

                //Check if link hit a portal
                if (portal is BluePortalProjectile)
                {
                    bluePortalLocation = new Vector2(portal.Location.X, portal.Location.Y);
                    if (redPortalDeployed && SharedProjectileMethods.ProjectileCollision(portal.LocationRect, link.locationRect))
                    {
                        portalCollision = "blue";
                    }
                }
                if (portal is RedPortalProjectile)
                {
                    redPortalLocation = new Vector2(portal.Location.X, portal.Location.Y);
                    if (bluePortalDeployed && SharedProjectileMethods.ProjectileCollision(portal.LocationRect, link.locationRect))
                    {
                        portalCollision = "red";
                    }
                }
            }

            //Teleport link if detected portalCollision
            if (portalCollision.Equals("blue"))
            {
                teleportLink(redPortalLocation, blocks);
                portalCollision = "none";
            }
            else if (portalCollision.Equals("red"))
            {
                teleportLink(bluePortalLocation, blocks);
                portalCollision = "none";
            }

            foreach (IProjectile portal in portalsToRemove)
            {
                portals.Remove(portal);
            }
        }

        public void AddPortals(ISet<IProjectile> portals)
        {
            string direct = SharedLinkProjectileMethods.FindUseItemDirection();
            if(!direct.Equals("none"))
            {
                if (bluePortalDeployed && redPortalDeployed)
                {
                    ISet<IProjectile> portalsToRemove = new HashSet<IProjectile>();
                    foreach (IProjectile portal in portals)
                    {
                        if (portal is BluePortalProjectile || portal is RedPortalProjectile)
                        {
                            portalsToRemove.Add(portal);
                        }
                    }
                    foreach (IProjectile portal in portalsToRemove)
                    {
                        portals.Remove(portal);
                    }
                    bluePortalDeployed = false;
                    redPortalDeployed = false;
                }
                else if (bluePortalDeployed)
                {
                    portals.Add(new RedPortalProjectile(spriteBatch, link.Location, direct));
                    redPortalDeployed = true;
                }
                else
                {
                    portals.Add(new BluePortalProjectile(spriteBatch, link.Location, direct));
                    bluePortalDeployed = true;
                }
            }
        }

        public void teleportLink(Vector2 portalLocation, ISet<IBlock> blocks)
        {
            Vector2 possibleLocation = new Vector2(link.Location.X, link.Location.Y);
            int i = 0;
            bool locationFound = false;
            while (i < 4 && !locationFound)
            {
                switch (i)
                {
                    case 0:
                        possibleLocation = new Vector2(portalLocation.X, portalLocation.Y - 55);
                        break;
                    case 1:
                        possibleLocation = new Vector2(portalLocation.X + 45, portalLocation.Y);
                        break;
                    case 2:
                        possibleLocation = new Vector2(portalLocation.X, portalLocation.Y + 55);
                        break;
                    case 3:
                        possibleLocation = new Vector2(portalLocation.X - 55, portalLocation.Y);
                        break;
                    default:
                        break;
                }
                locationFound = true;
                if (SharedProjectileMethods.LocationOutOfBounds(possibleLocation))
                {
                    locationFound = false;
                }
                else
                {
                    foreach (IBlock block in blocks)
                    {
                        if (SharedProjectileMethods.ProjectileCollision(new Rectangle((int)possibleLocation.X, (int)possibleLocation.Y, 48, 48), block.LocationRect))
                        {
                            locationFound = false;
                        }
                    }
                }
                i++;
            }
            if (locationFound)
            {
                link.Location = possibleLocation;
            }
        }
    }
}
