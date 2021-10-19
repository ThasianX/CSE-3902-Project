using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects.Items
{
    public class Triforce : IGameObject, IItem
    {
        public Vector2 Position { get; set; }

        ISprite sprite;

        public Triforce(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("triforce");
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
