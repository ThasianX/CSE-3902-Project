using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class WoodSwordPickup : IEquippable, ICollidable
    {
        public static WoodSwordPickup staticInstance = new WoodSwordPickup(Vector2.Zero);
        public IInventoryItem StaticInstance
        {
            get { return staticInstance; }
        }
        public string Name => "Wood Sword";
        public bool IsConsumable => false;
        public int MaxStackCount => 1;
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsMover => false;
        public string CollisionType => "PickUp";
        public WoodSwordPickup(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("woodSwordPickup");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Use(IPlayer player)
        {
            player.SwordAttack();
        }

        public Rectangle GetRectangle()
        {
            Dimensions dimensions = Sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, dimensions.width, dimensions.height);
        }
    }
}
