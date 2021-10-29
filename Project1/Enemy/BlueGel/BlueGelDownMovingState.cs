﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGelDownMovingState : IEnemyState
    {
        private BlueGel blueGel;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public BlueGelDownMovingState(BlueGel blueGel)
        {
            this.blueGel = blueGel;
            blueGel.sprite = SpriteFactory.Instance.CreateSprite("BlueGel_walking");
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
                case 1: blueGel.state = new BlueGelUpMovingState(blueGel); break;
                case 2: blueGel.state = new BlueGelLeftMovingState(blueGel); break;
                case 3: blueGel.state = new BlueGelRightMovingState(blueGel); break;
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
            blueGel.Position += deltaVector * blueGel.movingSpeed;
        }
    }
}