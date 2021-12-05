using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Key : IInventoryItem, ICollidable
    {
        public static Key staticInstance = new Key(Vector2.Zero);
        public IInventoryItem StaticInstance
        {
            get { return staticInstance; }
        }
        public string Name => "Key";
        public bool IsConsumable => true;
        public int MaxStackCount => 99;
        public Vector2 Position { get; set; }

        public ISprite Sprite { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Item";

        public Key(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("key");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 16);
        }
    }
}
