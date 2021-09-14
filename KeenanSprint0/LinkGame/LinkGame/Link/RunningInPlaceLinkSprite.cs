using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LinkGame.Interfaces;

namespace LinkGame
{
    class RunningInPlaceLinkSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private double prevTime;
        private double currentTime;
        private bool frame;
        public RunningInPlaceLinkSprite(Texture2D texture)
        {
            Texture = texture;
            prevTime = 0;
            currentTime = 0;
        }
        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.TotalGameTime.TotalMilliseconds;

            if ((currentTime - prevTime) >= 1000)
            {
                frame = !frame;
                prevTime = currentTime;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRect;

            if(frame)
            {
                sourceRect = new Rectangle(1, 11, 16, 16);
            } else {
                sourceRect = new Rectangle(18, 11, 16, 16);
            }

            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRect, Color.White);
            spriteBatch.End();
        }
    }
}
