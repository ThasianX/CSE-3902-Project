using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Interfaces
{
    interface ISprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Update();
    }
}
