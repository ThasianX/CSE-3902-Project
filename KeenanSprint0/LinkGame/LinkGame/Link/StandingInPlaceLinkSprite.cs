using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LinkGame.Interfaces;

namespace LinkGame
{
    class StandingInPlaceLinkSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        public StandingInPlaceLinkSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRect = new Rectangle(1, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRect, Color.White);
            spriteBatch.End();
        }
    }
}
