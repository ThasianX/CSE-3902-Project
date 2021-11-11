using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class FlashingRuby : IRupee, ICollidable
    {
        public Vector2 Position { get; set; }
        public string Name => "Ruby";
        public bool IsConsumable => true;
        public int MaxStackCount => 999;
        public ISprite Sprite { get; set; }
        public int amount => 25;
        public bool IsMover => false;
        public string CollisionType => "Rupee";

        public FlashingRuby(Vector2 position)
        {
            this.Position = position;
            Sprite = SpriteFactory.Instance.CreateSprite("flashingRuby");
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
