using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class StalfosLeftMovingState : IEnemyState
    {
        private Stalfos stalfos;
        private IAnimation leftMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public StalfosLeftMovingState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            leftMovingAnimation = new StalfosMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            timer = 0;
            currentDirection = Direction.Left;
            deltaVector = new Vector2(-1, 0);
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
                case 2: stalfos.state = new StalfosDownMovingState(stalfos); break;
                case 3: stalfos.state = new StalfosRightMovingState(stalfos); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, stalfos.Position);
        }

        public void Update()
        {
            timer++;
            if (timer == leftMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            stalfos.Position += deltaVector * stalfos.movingSpeed;
            sprite.Update();
        }
    }
}
