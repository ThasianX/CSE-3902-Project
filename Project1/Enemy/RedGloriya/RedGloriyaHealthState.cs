﻿using Project1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    class RedGloriyaHealthState : IHealthState
    {
        private ISprite sprite;
        private RedGloriya redGloriya;

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

        public RedGloriyaHealthState(RedGloriya redGloriya, int maxHealth)
        {
            this.redGloriya = redGloriya;
            health = this.maxHealth = maxHealth;

            sprite = SpriteFactory.Instance.CreateHealthSprite(this, "Name");
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(redGloriya.Position.X, redGloriya.Position.Y + 20));
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
        public void Heal(int heal)
        {

        }
    }
}
