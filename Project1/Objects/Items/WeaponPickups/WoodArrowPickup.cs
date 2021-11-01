using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodArrowPickup : IInventoryItem, ICollidable
    {
        public string Name => "Wood Arrow";
        public bool IsConsumable => true;
        public int MaxStackCount => 99;
        public Vector2 Position { get; set; }
        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "Item";
        public WoodArrowPickup(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("woodArrowPickup");
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
            Dimensions dimensions = sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }
    }
}
