using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Triforce : IInventoryItem, ICollidable
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }

        public static Triforce staticInstance = new Triforce(Vector2.Zero);
        public IInventoryItem StaticInstance
        {
            get { return staticInstance; }
        }
        public bool IsMover => false;
        public string CollisionType => "PickUp";
        public string Name => "Triforce";
        public bool IsConsumable => false;
        public int MaxStackCount => 1;

        public Triforce(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("triforce");
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
            return new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
        }
    }
}
