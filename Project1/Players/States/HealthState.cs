using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.PlayerStates
{
    public class HealthState: IHealthState
    {
        private ISprite sprite;
        private Player player;

        private int maxHealth;
        private int heartContainers;
        public int health { get; set; }


        public HealthState(Player player, int heartContainers)
        {
            this.player = player;
            this.heartContainers = heartContainers;
            maxHealth = heartContainers * Constants.HP_PER_HEART;
            health = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
            UIManager.Instance.UpdateHealthBar(maxHealth, heartContainers);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(player.Position.X, player.Position.Y + 20));
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            UIManager.Instance.UpdateHealthBar(health, heartContainers);

            if (health <= 0)
            {
                player.Die();
            }

        }
        public void Heal(int heal)
        {
            health += heal;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            UIManager.Instance.UpdateHealthBar(health, heartContainers);
        }
    }
}
