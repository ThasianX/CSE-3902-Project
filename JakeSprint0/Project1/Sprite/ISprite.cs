using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1
{
    public interface ISprite
    {
        bool Visible { set; get; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
