using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Map : IInstantUseItem, ICollidable
    {
        public Vector2 Position { get; set; }

        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "InstantUseItem";

        public Map(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("map");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void InstantUseItem(IPlayer player)
        {
            // To be implemented
            SoundManager.Instance.PlaySound("GetItem");
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 16);
        }
    }
}
