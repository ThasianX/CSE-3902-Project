using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class AnimatedSprite: ISprite
    {
        private int currentFrame = 0;

        private readonly Texture2D spriteSheet;

        IAnimation animation;

        public AnimatedSprite(Texture2D spriteSheet, IAnimation animation)
        {
            this.animation = animation;
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // define the space on the screen to draw the sprite
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, animation.Width, animation.Height);

            // choose which frame of animation to use
            int index = currentFrame / (animation.CycleLength / animation.FrameCount);

            // Draw
            spriteBatch.Draw(spriteSheet, destination, animation.Sources[index], Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == animation.CycleLength)
                currentFrame = 0;
        }
    }
}
