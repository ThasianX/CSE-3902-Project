using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class StalfosDownMovingState : IEnemyState
    {
        private Stalfos stalfos;
        private IAnimation downMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public StalfosDownMovingState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            downMovingAnimation = new StalfosMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(downMovingAnimation);
            timer = 0;
            currentDirection = Direction.Down;
            deltaVector = new Vector2(0, 1);
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
                case 1: stalfos.state = new StalfosUpMovingState(stalfos); break;
                case 2: stalfos.state = new StalfosLeftMovingState(stalfos); break;
                case 3: stalfos.state = new StalfosRightMovingState(stalfos); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, stalfos.position);
        }

        public void Update()
        {
            timer++;
            if (timer == downMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            stalfos.position += deltaVector * stalfos.movingSpeed;
            sprite.Update();
        }
    }
}
