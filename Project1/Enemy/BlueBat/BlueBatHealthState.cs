using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class BlueBatHealthState : IHealthState
    {
        private ISprite sprite;
        private BlueBat blueBat;

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

        public BlueBatHealthState(BlueBat blueBat, int maxHealth)
        {
            this.blueBat = blueBat;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(blueBat.Position.X, blueBat.Position.Y + 20));
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
