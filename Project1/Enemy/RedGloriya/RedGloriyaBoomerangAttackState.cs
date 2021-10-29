using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.Enemy
{
    public class RedGloriyaBoomerangAttackState : IEnemyState
    {
        private RedGloriya redGloriya;
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

        public RedGloriyaBoomerangAttackState(RedGloriya redGloriya, Direction currentDirection)
        {
            this.redGloriya = redGloriya;
            this.direction = currentDirection;
            switch (direction)
            {
                case Direction.Up:
                    redGloriya.sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_up");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(0, -boomerangOffset), currentDirection, activeFrameCount);
                    break;

                case Direction.Right:
                    redGloriya.sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_right");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(boomerangOffset, 0), currentDirection, activeFrameCount);
                    break;

                case Direction.Down:
                    redGloriya.sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_down");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(0, boomerangOffset), currentDirection, activeFrameCount);
                    break;

                case Direction.Left:
                    redGloriya.sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_left");
                    this.boomerang = new WoodBoomerang(redGloriya.Position + new Vector2(-boomerangOffset, 0), currentDirection, activeFrameCount);
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
                case 0: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 1: redGloriya.state = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaRightMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaLeftMovingState(redGloriya); break;
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