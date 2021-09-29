using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class MovingAnimatedSprite : ISprite
    {
        private int currentFrame = 0;
        private readonly int cycleLength;

        private readonly ArrayList sources;

        private readonly Texture2D spriteSheet;
        private readonly Action<int, int> shiftPosition;

        public MovingAnimatedSprite(Texture2D spriteSheet, ArrayList sources, int cycleLength, Action<int, int> shiftPosition)
        {
            this.cycleLength = cycleLength;
            this.sources = sources;
            this.spriteSheet = spriteSheet;
            this.shiftPosition = shiftPosition;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, Constants.SPRITE_WIDTH, Constants.SPRITE_HEIGHT);

            int index = currentFrame / (cycleLength / sources.Count);
            spriteBatch.Draw(spriteSheet, destination, (Rectangle)sources[index], Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == cycleLength)
                currentFrame = 0;

            shiftPosition(1, 0);
        }
    }
}
