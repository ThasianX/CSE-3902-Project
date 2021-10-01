using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PlayerStates
{
    public class HealthState: IHealthState
    {
        private ISprite sprite;
        private Player player;

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

        public HealthState(Player player, int maxHealth)
        {
            this.player = player;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(player.position.X, player.position.Y + 20));
        }

        public void TakeDamage(int damage)
        {
            if (health <= 0) {
                health = maxHealth;
            } else {
                health -= damage;
            }
        }
    }
}
