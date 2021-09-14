using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class DynamicSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public bool Visible { get; set; }

        // Horizontal displacement of the sprite in pixels
        public int yOffset;
        public int maxOffset;

        // how fast the sprite moves across the screen in pixels per frame;
        int speed;
        
        public DynamicSprite(Texture2D texture, int speed, int maxOffset)
        {
            Texture = texture;
            Visible = true;
            yOffset = 0;
            this.speed = speed;
            this.maxOffset = maxOffset;

            Visible = false;
        }

        public void Update()
        {
            yOffset = (yOffset + speed) % maxOffset;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!Visible) return;

            spriteBatch.Draw(Texture, location + new Vector2(0, yOffset), Color.White);
        }
    }
}
