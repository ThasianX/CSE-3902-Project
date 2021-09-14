using System;
using System.Collections.Generic;
using System.Text;
using LinkGame.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LinkGame
{
    class MovingLinkSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int adjust;
        private bool direction;
        private bool frame;
        private double prevTime;
        private double currentTime;
        public MovingLinkSprite(Texture2D texture)
        {
            Texture = texture;
            prevTime = 0;
            currentTime = 0;
            adjust = 0;
            direction = true;
        }
        public void Update(GameTime gameTime)
        {
            if (adjust == 250 || adjust == -250)
            {
                direction = !direction;
            }
            if (direction)
            {
                adjust += 2;
            }
            else
            {
                adjust -= 2;
            }
            currentTime += gameTime.TotalGameTime.TotalMilliseconds;

            if ((currentTime - prevTime) >= 10000)
            {
                frame = !frame;
                prevTime = currentTime;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRect;

            if (frame)
            {
                sourceRect = new Rectangle(1, 11, 16, 16);
            }
            else
            {
                sourceRect = new Rectangle(18, 11, 16, 16);
            }

            Rectangle destinationRectangle = new Rectangle((int)location.X + adjust, (int)location.Y, 15, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRect, Color.White);
            spriteBatch.End();
        }
    }
}
