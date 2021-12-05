using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class BombPickup : IInventoryItem, ICollidable
    {
        public static BombPickup staticInstance = new BombPickup(Vector2.Zero);
        public IInventoryItem StaticInstance
        {
            get { return staticInstance; }
        }
        public string Name => "Bomb";
        public bool IsConsumable => true;
        public int MaxStackCount => 10;
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Item";
        public BombPickup(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("bombPickup");
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
            Dimensions dimensions = Sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }
    }
}
