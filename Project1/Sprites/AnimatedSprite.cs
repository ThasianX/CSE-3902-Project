using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class AnimatedSprite: ISprite
    {
        readonly (int height, int width) dimensions;

        private readonly (int x, int y)[] sources;

        private readonly Texture2D spriteSheet;

        private bool isAnimated;

        private double timePerSource, timeCounter;

        private int currentSourceIndex, sourceCount;

        // Constructor for animated sprites (more than 1 source)
        public AnimatedSprite(Texture2D spriteSheet, (int height, int width) dimensions, (int x, int y)[] sources, double time)
        {
            this.spriteSheet = spriteSheet;

            sourceCount = sources.Length;
            this.sources = sources;
            this.dimensions = dimensions;

            // the sprite is animated if it has more than one source
            isAnimated = sourceCount > 0;

            // how much time should pass before the sprite switches sources
            timePerSource = time / sourceCount;

            currentSourceIndex = 0;

            timeCounter = 0f;

        }

        // Old constructor (needed to compile)

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // define the rectangle on the screen to draw the sprite
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, dimensions.width, dimensions.height);

            // define the rectangle on the texture to get the sprite
            Rectangle source = new Rectangle(sources[currentSourceIndex].x, sources[currentSourceIndex].y, dimensions.width, dimensions.height);

            // Draw
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            // no need to update if the sprite does not animate
            if (!isAnimated)
                return;

            if (timeCounter > timePerSource)
            {
                currentSourceIndex++;
                timeCounter = 0;
            }

            currentSourceIndex %= sourceCount;

            // increment the timer by the realtime since last frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
