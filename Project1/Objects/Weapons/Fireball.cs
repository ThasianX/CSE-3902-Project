using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Objects
{
    public class Fireball : IProjectile, ICollidable
    {
        public int moveSpeed;
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Projectile";
        public IGameObject Owner { get; set; }
        // Distance Fireball travels from Aquamentus
        private int maxRange = 250;
        private Vector2 deltaVector;
        private Vector2 fireBalOffset;

        private ISprite fireBallSprite;

        public Fireball(Vector2 position, Vector2 fireBalOffset, int frames, IGameObject owner)
        {
            this.Position = position;
            this.Owner = owner;
            // The direction for Aquamentus will always be left, so the delta vector will be the same
            deltaVector = new Vector2(-1, 0);
            this.fireBalOffset = fireBalOffset;
            moveSpeed = (maxRange * 2) / frames;
            fireBallSprite = SpriteFactory.Instance.CreateSprite("fireball");
            SoundManager.Instance.PlaySound("Candle");
        }

        public void Update(GameTime gameTime)
        {
            Position += deltaVector + fireBalOffset;
            fireBallSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireBallSprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 8, 10);
        }
    }
}
