﻿using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class RedGloriyaRightMovingState : IEnemyState
    {
        private IEnemy redGloriya;
        // Right moving state, so Direction.Right
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;
        private int counter;

        public RedGloriyaRightMovingState(IEnemy redGloriya)
        {
            this.redGloriya = redGloriya;
            redGloriya.sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_right");
            currentDirection = Direction.Right;
            deltaVector = new Vector2(1, 0);
        }

        public void FireBallAttack()
        {
        }

        // Change current RedGloriya state to RedGloriyaAttackState
        public void BoomerangAttack()
        {
            redGloriya.state = new RedGloriyaBoomerangAttackState(redGloriya, currentDirection);
        }

        // Change current RedGloriya state to a random direction state.
        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: redGloriya.state = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaLeftMovingState(redGloriya); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When complete an animation cycle length, make a choice
            if (timer++ == counter)
            {
                // 1/4 chance to do a BoomerangAttack
                choice = rand.Next(4);
                if (choice == 0)
                {
                    BoomerangAttack();
                }
                // 3/4 chance to do a ChangeDirection
                else
                {
                    ChangeDirection();
                }
                timer = 0;
            }
            redGloriya.Position += deltaVector * redGloriya.movingSpeed;
        }
    }
}
