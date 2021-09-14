using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class AnimatedDynamicSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public bool Visible { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        private int currentFrame;
        private int totalFrames;

        // vertical displacement of the sprite in pixels
        public int xOffset;
        public int maxOffset;

        // how fast the sprite moves across the screen in pixels per frame;
        int speed;

        public AnimatedDynamicSprite(Texture2D texture, int rows, int columns, int speed, int maxOffset)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            this.speed = speed;
            this.maxOffset = maxOffset;

            Visible = false;
        }

        public void Update()
        {
            xOffset = (xOffset + speed) % maxOffset;

            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!Visible) return;

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X + xOffset, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
