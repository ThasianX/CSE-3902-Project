using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class StaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public bool Visible { get; set; }

        public StaticSprite(Texture2D texture)
        {
            Texture = texture;

            Visible = false;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!Visible) return;

            spriteBatch.Draw(Texture, location, Color.White);
        }
    }
}
