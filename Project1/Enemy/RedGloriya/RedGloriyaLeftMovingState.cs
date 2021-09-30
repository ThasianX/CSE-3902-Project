using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriyaLeftMovingState : IEnemyState
    {
        private RedGloriya redGloriya;
        private IAnimation leftMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private Direction currenrDirection;
        public int cycleLength { get; }

        public RedGloriyaLeftMovingState(RedGloriya redGloriya)
        {
            this.redGloriya = redGloriya;
            leftMovingAnimation = new RedGloriyaLeftMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            cycleLength = leftMovingAnimation.CycleLength;
            currenrDirection = Direction.Left;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
            // need implementation
        }

        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: redGloriya.state = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaRightMovingState(redGloriya); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, redGloriya.position);
        }

        public void Update()
        {
            redGloriya.position += new Vector2(-1, 0) * redGloriya.movingSpeed;
            sprite.Update();
        }
    }
}
