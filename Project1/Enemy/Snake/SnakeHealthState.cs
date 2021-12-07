using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class SnakeHealthState : IHealthState
    {
        private ISprite sprite;
        private Snake snake;

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

        public SnakeHealthState(Snake snake, int maxHealth)
        {
            this.snake = snake;
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
            //sprite.Draw(spriteBatch, new Vector2(snake.Position.X, snake.Position.Y + 20));
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
