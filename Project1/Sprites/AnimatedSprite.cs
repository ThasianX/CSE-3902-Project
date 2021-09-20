using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class AnimatedSprite: ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength;

        private readonly Texture2D spriteSheet;
        private readonly ArrayList sources;

        public AnimatedSprite(Texture2D spriteSheet, ArrayList sources, int cycleLength)
        {
            this.cycleLength = cycleLength;
            this.sources = sources;
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);
            int index = currentFrame / (cycleLength / sources.Count);
            spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[index], Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;
        }
    }
}
