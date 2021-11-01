using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Update(GameTime gameTime);
        Dimensions GetDimensions();
    }
}
