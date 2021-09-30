using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Interfaces
{
    interface IBlock
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 location) { }

        public void Update() { }

    }
}
