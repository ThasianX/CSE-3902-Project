using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Heart : IInstantUseItem, ICollidable
    {
        public Vector2 Position { get; set; }
        public int heartHeal = 30;
        ISprite sprite;
        public bool IsMover => false;
        public string CollisionType => "InstantUseItem";
        public Heart(Vector2 position)
        {
            this.Position = position;
            sprite = SpriteFactory.Instance.CreateSprite("heart");
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
            player.Heal(heartHeal);
            SoundManager.Instance.PlaySound("GetHeart");
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 7, 8);
        }
    }
}
