﻿using System;
using Microsoft.Xna.Framework;
using Project1.Objects;

namespace Project1.Enemy
{
    public class RedGloriyaBoomerangAttackState : IEnemyState
    {
        private IEnemy redGloriya;
        // The direction passed in
        private Direction direction;
        // The WoodBoomerang instance used for Update and Draw
        private WoodBoomerang boomerang;
        // Not sure, need to ask Keenan !!
        private int boomerangOffset = 8;
        // The length of animation frame boomerang will Update, also Not sure, need to ask Keenan !!
        private int activeFrameCount = 50;
        private int choice;
        private int timer;
        private Random rand = new Random();

        public RedGloriyaBoomerangAttackState(IEnemy redGloriya, Direction currentDirection)
        {
            this.redGloriya = redGloriya;
            this.direction = currentDirection;
            switch (direction)
            {
                case Direction.Up:
                    redGloriya.Sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_up");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(0, -boomerangOffset), currentDirection, activeFrameCount, Owner.Enemy);
                    break;

                case Direction.Right:
                    redGloriya.Sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_right");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(boomerangOffset, 0), currentDirection, activeFrameCount, Owner.Enemy);
                    break;

                case Direction.Down:
                    redGloriya.Sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_down");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(0, boomerangOffset), currentDirection, activeFrameCount, Owner.Enemy);
                    break;

                case Direction.Left:
                    redGloriya.Sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_left");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(-boomerangOffset, 0), currentDirection, activeFrameCount, Owner.Enemy);
                    break;
            }
            GameObjectManager.Instance.AddOnNextFrame(boomerang);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            choice = rand.Next(4);
            switch (choice)
            {
                case 0: redGloriya.State = new RedGloriyaDownMovingState(redGloriya); break;
                case 1: redGloriya.State = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.State = new RedGloriyaRightMovingState(redGloriya); break;
                case 3: redGloriya.State = new RedGloriyaLeftMovingState(redGloriya); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When finish BoomerangAttack, change a random direction
            if (timer++ == activeFrameCount)
            {
                ChangeDirection();
            }
        }
    }
}