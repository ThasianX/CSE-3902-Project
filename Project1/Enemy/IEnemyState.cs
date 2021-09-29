﻿using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public interface IEnemyState
    {
        public int cycleLength {get;}
        void FireBallAttack();
        void BoomerangAttack();
        void ChangeDirection();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
