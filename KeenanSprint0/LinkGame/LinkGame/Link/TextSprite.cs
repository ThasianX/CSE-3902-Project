using System;
using System.Collections.Generic;
using System.Text;
using LinkGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LinkGame
{
    class TextSprite
    {
        private SpriteFont font;

        public TextSprite(SpriteFont Font)
        {
            font = Font;
        }
        public void Update(GameTime gametime)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Program Made By: Keenan Anderson", location, Color.Black);
            spriteBatch.DrawString(font, "Sprite from: https://www.spriters-resource.com/nes/legendofzelda/", new Vector2(location.X, location.Y+50), Color.Black);
            spriteBatch.End();
        }
    }
}
