﻿using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class WallMasterDownMovingState : IEnemyState
    {
        private IEnemy wallMaster;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public WallMasterDownMovingState(IEnemy wallMaster)
        {
            this.wallMaster = wallMaster;
            wallMaster.Sprite = SpriteFactory.Instance.CreateSprite("WallMaster_woving");
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
                case 1: wallMaster.State = new WallMasterUpMovingState(wallMaster); break;
                case 2: wallMaster.State = new WallMasterLeftMovingState(wallMaster); break;
                case 3: wallMaster.State = new WallMasterRightMovingState(wallMaster); break;
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
            wallMaster.Position += deltaVector * wallMaster.MovingSpeed;
        }
    }
}
