using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Sprites
{
    class MovingSprite: ISprite
    {

        private readonly Rectangle source = new Rectangle(326, 58, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);

        private readonly Texture2D spriteSheet;
        private readonly Action<int, int> shiftPosition;

        public MovingSprite(Texture2D spriteSheet, Action<int, int> shiftPosition)
        {
            this.spriteSheet = spriteSheet;
            this.shiftPosition = shiftPosition;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, SpriteDimensions.WIDTH, SpriteDimensions.HEIGHT);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }

        public void Update()
        {
            shiftPosition(0, -1);
        }
    }
}
