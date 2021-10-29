using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Interfaces
{
    public interface IGameObject
    {
        public Vector2 Position { get; set; }
        public void Draw(SpriteBatch spriteBatch) { }

        public void Update(GameTime gameTime) { }

    }
}
