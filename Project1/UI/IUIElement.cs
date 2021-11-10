using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1
{
    interface IUIElement
    {
        public Vector2 Position { get; set; }
        public void Draw(SpriteBatch sb);
        public ISprite[] Sprites { get; set; }
    }
}
