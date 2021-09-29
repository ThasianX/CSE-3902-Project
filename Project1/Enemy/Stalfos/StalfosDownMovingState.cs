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
        private int cycleLength;
        private int timer;

        public StalfosDownMovingState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            downMovingAnimation = new StalfosMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(downMovingAnimation);
            cycleLength = downMovingAnimation.CycleLength;
            timer = 0;
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
            if (timer == cycleLength)
            {
                ChangeDirection();
            }
            stalfos.position = stalfos.position + new Vector2(0, 1) * stalfos.movingSpeed;
            sprite.Update();
        }
    }
}
