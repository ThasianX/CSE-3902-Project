using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class BombPickup : IInventoryItem, ICollidable
    {
        public string Name => "Bomb";
        public bool IsConsumable => true;
        public int MaxStackCount => 10;
        public Vector2 Position { get; set; }
        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "Item";
        public BombPickup(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("bombPickup");
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
