using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.NPC
{
    public class OldMan : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        public bool IsMover => false;
        public string CollisionType => "Block";
        public bool isFreeze { get; set; }
        public OldMan(Vector2 position)
        {
            this.Position = position;
            State = new OldManStaticState(this);
            MovingSpeed = 0f;
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

        public void Freeze()
        {
        }

        public void Defreeze(GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch, Color color) { }
    }
}
