using System;
using System.Collections.Generic;
using System.Text;
using LinkGame.Link;
using LinkGame.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LinkGame.Link
{
    class LinkSpriteFactory
    {
        public Texture2D linkSpriteTexture { get; set; }
        private StandingInPlaceLinkSprite standingInPlaceLinkSprite;
        private RunningInPlaceLinkSprite runningInPlaceLinkSprite;
        private MovingStillLinkSprite movingStillLinkSprite;
        private MovingLinkSprite movingLinkSprite;

        public LinkSpriteFactory(Texture2D texture)
        {
            linkSpriteTexture = texture;
        }

        public void LinkSpriteCreation()
        {
        standingInPlaceLinkSprite = new StandingInPlaceLinkSprite(linkSpriteTexture);
        runningInPlaceLinkSprite = new RunningInPlaceLinkSprite(linkSpriteTexture);
        movingStillLinkSprite = new MovingStillLinkSprite(linkSpriteTexture);
        movingLinkSprite = new MovingLinkSprite(linkSpriteTexture);
        }
        public void Update(GameTime gameTime, int spriteMode)
        {
            switch (spriteMode)
            {
                case 1:
                    // code block
                    standingInPlaceLinkSprite.Update(gameTime);
                    break;
                case 2:
                    // code block
                    runningInPlaceLinkSprite.Update(gameTime);
                    break;
                case 3:
                    // code block
                    movingStillLinkSprite.Update(gameTime);
                    break;
                case 4:
                    // code block
                    movingLinkSprite.Update(gameTime);
                    break;
                default:
                    // code block
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int drawMode)
        {
            switch (drawMode)
            {
                case 1:
                    // code block
                    standingInPlaceLinkSprite.Draw(spriteBatch, location);
                    break;
                case 2:
                    // code block
                    runningInPlaceLinkSprite.Draw(spriteBatch, location);
                    break;
                case 3:
                    // code block
                    movingStillLinkSprite.Draw(spriteBatch, location);
                    break;
                case 4:
                    // code block
                    movingLinkSprite.Draw(spriteBatch, location);
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
