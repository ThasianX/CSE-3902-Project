using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Explosion : IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }
        ISprite sprite = SpriteFactory.Instance.CreateSprite("explosion");
        public bool IsMover => false;

        public string CollisionType => "Explosion";
        private double activeTime = 0.25;
        private double counter = 0;
        public Explosion(Vector2 position)
        {
            this.Position = position;
            SoundManager.Instance.PlaySound("BombBlow");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (counter >= activeTime)
            {
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            counter += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public Rectangle GetRectangle()
        {
            Dimensions dimensions = sprite.GetDimensions();
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
