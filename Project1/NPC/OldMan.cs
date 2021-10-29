using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.NPC
{
    public class OldMan : IEnemy, ICollidable
    {
        public IEnemyState state;
        public ISprite sprite { get; set; }
        public Vector2 Position { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Block";
        public OldMan(Vector2 position)
        {
            this.Position = position;
            state = new OldManStaticState(this);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
        }

        public void TakeDamage(int damage)
        {
        }

        public void Update(GameTime gameTime)
        {
           sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
