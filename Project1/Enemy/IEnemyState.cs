﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public interface IEnemyState
    {
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some class in Item
        void FireBallAttack();
        // Will take the position of current IEnemy instance and the direction of current IEnemy to some Enemy Attack State (RedGloriyaAttackState)
        void BoomerangAttack();
        // Base on current direction, randomly change to a different direction
        void ChangeDirection();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
