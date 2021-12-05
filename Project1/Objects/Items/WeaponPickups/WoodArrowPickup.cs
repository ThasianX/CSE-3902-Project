using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodArrowPickup : IInventoryItem, ICollidable
    {
        public static WoodArrowPickup staticInstance = new WoodArrowPickup(Vector2.Zero);
        public IInventoryItem StaticInstance
        {
            get { return staticInstance; }
        }
        public string Name => "Wood Arrow";
        public bool IsConsumable => true;
        public int MaxStackCount => 99;
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Item";
        public WoodArrowPickup(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("woodArrowPickup");
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
