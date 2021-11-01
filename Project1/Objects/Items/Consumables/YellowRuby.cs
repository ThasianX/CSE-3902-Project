using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class YellowRuby : IInventoryItem, ICollidable
    {
        public string Name => "Ruby";
        public bool IsConsumable => true;
        public int MaxStackCount => 999;
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "Item";
        public YellowRuby(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("yellowRuby");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 16);
        }
    }
}
