﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBatRightMovingState : IEnemyState
    {
        private BlueBat blueBat;
        private IAnimation rightMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        public int cycleLength { get; }

        public BlueBatRightMovingState(BlueBat blueBat)
        {
            this.blueBat = blueBat;
            rightMovingAnimation = new BlueBatMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            cycleLength = rightMovingAnimation.CycleLength;
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
                case 3: blueBat.state = new BlueBatLeftMovingState(blueBat); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueBat.position);
        }

        public void Update()
        {
            blueBat.position = blueBat.position + new Vector2(1, 0) * blueBat.movingSpeed;
            sprite.Update();
        }
    }
}