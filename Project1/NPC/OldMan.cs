using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.NPC
{
    public class OldMan : IEnemy, ICollidable
    {
        public IEnemyState state;
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
           // The old man do not update
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public bool Immune()
        {
            return true;
            // NPC do not take damage
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }
    }
}
