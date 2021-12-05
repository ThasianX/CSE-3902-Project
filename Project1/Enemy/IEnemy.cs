using Project1.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemy : IGameObject
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public float MovingSpeed { get; set; }
        public LootTable LootTable { get; }
        public void Draw(SpriteBatch spriteBatch, Color color);
        public void FireBallAttack();
        public void BoomerangAttack();
        public void ChangeDirection();
        public void TakeDamage(int damage);
        public void Freeze(float freezeTime);
        public void Defreeze(GameTime gameTime);
        public bool isFreeze { get; set; }

    }
}
