using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class AquamentusHealthState : IHealthState
    {
        private ISprite sprite;
        private Aquamentus aquamentus;

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

        public AquamentusHealthState(Aquamentus aquamentus, int maxHealth)
        {
            this.aquamentus = aquamentus;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Don't want to show this
            //sprite.Draw(spriteBatch, new Vector2(aquamentus.Position.X, aquamentus.Position.Y + 20));
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
        public void Heal(int heal)
        {

        }

        public void AddHeartContainer() { }
    }
}
