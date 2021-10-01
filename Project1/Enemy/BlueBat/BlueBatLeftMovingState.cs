﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBatLeftMovingState : IEnemyState
    {
        private BlueBat blueBat;
        private IAnimation leftMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public BlueBatLeftMovingState(BlueBat blueBat)
        {
            this.blueBat = blueBat;
            leftMovingAnimation = new BlueBatMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            timer = 0;
            currentDirection = Direction.Left;
            deltaVector = new Vector2(-1, 0);
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
                case 1: blueBat.state = new BlueBatUpMovingState(blueBat); break;
                case 2: blueBat.state = new BlueBatDownMovingState(blueBat); break;
                case 3: blueBat.state = new BlueBatRightMovingState(blueBat); break;
            }
        }
        public void Update()
        {
            timer++;
            if (timer == leftMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }

            blueBat.position += deltaVector * blueBat.movingSpeed;
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueBat.position);
        }
    }
}

