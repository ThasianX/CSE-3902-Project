using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class BlueGelHealthState : IHealthState
    {
        private ISprite sprite;
        private BlueGel blueGel;

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

        public BlueGelHealthState(BlueGel blueGel, int maxHealth)
        {
            this.blueGel = blueGel;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteGelch)
        {
            // Don't want to show this
            //sprite.Draw(spriteGelch, new Vector2(blueGel.Position.X, blueGel.Position.Y + 20));
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