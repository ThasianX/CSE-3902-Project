﻿using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class FlameDownMovingState : IEnemyState
    {
        private IEnemy flame;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public FlameDownMovingState(IEnemy flame)
        {
            this.flame = flame;
            flame.Sprite = SpriteFactory.Instance.CreateSprite("Flame_moving");
            timer = 0;
            currentDirection = Direction.Down;
            deltaVector = new Vector2(0, 1);
            counter = 30;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: flame.State = new FlameUpMovingState(flame); break;
                case 2: flame.State = new FlameLeftMovingState(flame); break;
                case 3: flame.State = new FlameRightMovingState(flame); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == counter)
            {
                ChangeDirection();
                timer = 0;
            }
            flame.Position += deltaVector * flame.MovingSpeed;
        }
    }
}

