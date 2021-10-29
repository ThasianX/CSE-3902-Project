using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class StalfosHealthState : IHealthState
    {
        private ISprite sprite;
        private Stalfos stalfos;

        private int maxHealth;
        private int _health;
        public int health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public StalfosHealthState(Stalfos stalfos, int maxHealth)
        {
            this.stalfos = stalfos;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(stalfos.Position.X, stalfos.Position.Y + 20));
        }

        public void TakeDamage(int damage)
        {
            if (health <= 0)
            {
                health = maxHealth;
            }
            else
            {
                health -= damage;
            }
        }
    }
}
