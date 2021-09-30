using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriyaUpMovingState : IEnemyState
    {
        private RedGloriya redGloriya;
        private IAnimation upMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private Direction currenrDirection;
        public int cycleLength { get; }

        public RedGloriyaUpMovingState(RedGloriya redGloriya)
        {
            this.redGloriya = redGloriya;
            upMovingAnimation = new RedGloriyaUpMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(upMovingAnimation);
            cycleLength = upMovingAnimation.CycleLength;
            currenrDirection = Direction.Up;
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
                case 1: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaLeftMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaRightMovingState(redGloriya); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, redGloriya.position);
        }

        public void Update()
        {
            redGloriya.position += new Vector2(0, -1) * redGloriya.movingSpeed;
            sprite.Update();
        }
    }
}
