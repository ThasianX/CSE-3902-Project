﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGelDownMovingState : IEnemyState
    {
        private BlueGel blueGel;
        private IAnimation downMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        public int cycleLength { get; }

        public BlueGelDownMovingState(BlueGel blueGel)
        {
            this.blueGel = blueGel;
            downMovingAnimation = new BlueGelMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(downMovingAnimation);
            cycleLength = downMovingAnimation.CycleLength;
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
                case 1: blueGel.state = new BlueGelUpMovingState(blueGel); break;
                case 2: blueGel.state = new BlueGelLeftMovingState(blueGel); break;
                case 3: blueGel.state = new BlueGelRightMovingState(blueGel); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueGel.position);
        }

        public void Update()
        {
            blueGel.position = blueGel.position + new Vector2(0, 1) * blueGel.movingSpeed;
            sprite.Update();
        }
    }
}