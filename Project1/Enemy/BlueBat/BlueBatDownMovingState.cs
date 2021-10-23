﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBatDownMovingState : IEnemyState
    {
        private BlueBat blueBat;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public BlueBatDownMovingState(BlueBat blueBat)
        {
            this.blueBat = blueBat;
            sprite = SpriteFactory.Instance.CreateSprite("BlueBat_woving");
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
                case 1: blueBat.state = new BlueBatUpMovingState(blueBat); break;
                case 2: blueBat.state = new BlueBatLeftMovingState(blueBat); break;
                case 3: blueBat.state = new BlueBatRightMovingState(blueBat); break;
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
            blueBat.Position += deltaVector * blueBat.movingSpeed;
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueBat.Position);
        }
    }
}
