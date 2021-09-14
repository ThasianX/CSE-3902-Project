using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class AnimatedSprite: ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength = 30;

        private readonly Texture2D spriteSheet;
        private readonly ArrayList sources = new ArrayList() {
            new Rectangle(176, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT),
            new Rectangle(206, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT),
            new Rectangle(236, 118, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT)
        };

        public AnimatedSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);

            if (currentFrame > cycleLength / 3 && currentFrame <= (2 * cycleLength) / 3)
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[1], Color.White);
            }
            else if (currentFrame >= (2 * cycleLength) / 3)
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[2], Color.White);
            }
            else
            {
                spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[0], Color.White);
            }
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;
        }
    }
}
