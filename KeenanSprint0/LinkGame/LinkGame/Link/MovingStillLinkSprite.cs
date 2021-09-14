using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LinkGame.Interfaces;

namespace LinkGame
{
    class MovingStillLinkSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int adjust;
        private bool direction;
        public MovingStillLinkSprite(Texture2D texture)
        {
            Texture = texture;
            adjust = 0;
            direction = true;
        }
        public void Update(GameTime gameTime)
        {
            if (adjust == 150 || adjust == -150)
            {
                direction = !direction;
            }
            if (direction)
            {
                adjust += 2;
            } else
            {
                adjust -= 2;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRect = new Rectangle(1, 11, 16, 16);

            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y+adjust, 15, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRect, Color.White);
            spriteBatch.End();
        }
    }
}
