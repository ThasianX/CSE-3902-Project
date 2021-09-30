using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriyaRightMovingState : IEnemyState
    {
        private RedGloriya redGloriya;
        private IAnimation rightMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private Direction currenrDirection;
        public int cycleLength { get; }

        public RedGloriyaRightMovingState(RedGloriya redGloriya)
        {
            this.redGloriya = redGloriya;
            rightMovingAnimation = new RedGloriyaRightMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            cycleLength = rightMovingAnimation.CycleLength;
            currenrDirection = Direction.Right;
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
                case 1: redGloriya.state = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaLeftMovingState(redGloriya); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, redGloriya.position);
        }

        public void Update()
        {
            redGloriya.position = redGloriya.position + new Vector2(1, 0) * redGloriya.movingSpeed;
            sprite.Update();
        }
    }
}
