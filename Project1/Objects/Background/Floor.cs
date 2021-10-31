using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Floor: IGameObject
    {
        public Vector2 Position { get; set; }

        ISprite sprite;

        public Floor(Vector2 position, int variation)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("floor" + variation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
