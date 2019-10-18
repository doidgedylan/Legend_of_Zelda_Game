﻿using Microsoft.Xna.Framework;
using Legend_of_zelda_game.LinkSprites;

namespace Legend_of_zelda_game
{

    public class LinkHurtUpState : ILinkState
    {
        private Link link;
        int currentFrame;
        int totalFrames;
        int endPosition;

        public LinkHurtUpState(Link link)
        {
            this.link = link;
            currentFrame = 0;
            totalFrames = 30;
            endPosition = 400;
        }

        public void Update()
        {
            LinkHurtUpSprite linkHurtUpSprite = new LinkHurtUpSprite(link);

            currentFrame++;
            if (currentFrame <= 15 && link.Location.Y <= endPosition)
            {
                link.Location = Vector2.Add(link.Location, new Vector2(0, link.hurtSpeed));
            }
            else if (link.Location.Y >= endPosition)
            {
                link.Location = new Vector2(link.Location.X, 434);
            }

            link.tint = link.hurtColors[currentFrame / 5];
            linkHurtUpSprite.Draw();

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                link.state = new LinkIdleUpState(link);
                link.tint = Color.White;
            }
        }
    }
}
