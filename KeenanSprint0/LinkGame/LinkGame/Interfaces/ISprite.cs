using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LinkGame.Interfaces
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
