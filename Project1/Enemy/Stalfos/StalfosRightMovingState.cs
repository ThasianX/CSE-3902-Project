﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class StalfosRightMovingState : IEnemyState
    {
        private Stalfos stalfos;
        private IAnimation rightMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public StalfosRightMovingState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            rightMovingAnimation = new StalfosMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            timer = 0;
            currentDirection = Direction.Right;
            deltaVector = new Vector2(1, 0);
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
                case 1: stalfos.state = new StalfosUpMovingState(stalfos); break;
                case 2: stalfos.state = new StalfosDownMovingState(stalfos); break;
                case 3: stalfos.state = new StalfosLeftMovingState(stalfos); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, stalfos.position);
        }

        public void Update()
        {
            timer++;
            if (timer == rightMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            stalfos.position += deltaVector * stalfos.movingSpeed;
            sprite.Update();
        }
    }
}
