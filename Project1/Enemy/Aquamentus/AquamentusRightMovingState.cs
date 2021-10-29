﻿using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class AquamentusRightMovingState : IEnemyState
    {
        private IEnemy aquamentus;
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int counter;

        public AquamentusRightMovingState(IEnemy aquamentus)
        {
            this.aquamentus = aquamentus;
            aquamentus.sprite = SpriteFactory.Instance.CreateSprite("aquamentus_walking");
            // All direction for Aquamentus is facing left
            currentDirection = Direction.Left;
            deltaVector = new Vector2(1, 0);
            counter = 30;
        }

        public void FireBallAttack()
        {
            aquamentus.state = new AquamentusFireballAttackState(aquamentus);
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            aquamentus.state = new AquamentusLeftMovingState(aquamentus);
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == counter)
            {
                // 1/3 chance to do a FireBallAttack
                choice = rand.Next(3);
                if (choice == 0)
                {
                    FireBallAttack();
                }
                // 2/3 chance to do a ChangeDirection
                else
                {
                    ChangeDirection();
                }
                timer = 0;
            }
            aquamentus.Position += deltaVector * aquamentus.movingSpeed;
        }
    }
}
