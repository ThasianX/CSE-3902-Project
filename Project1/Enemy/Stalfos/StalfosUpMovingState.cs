using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class StalfosUpMovingState : IEnemyState
    {
        private Stalfos stalfos;
        private IAnimation upMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public StalfosUpMovingState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            upMovingAnimation = new StalfosMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(upMovingAnimation);
            timer = 0;
            currentDirection = Direction.Up;
            deltaVector = new Vector2(0, -1);
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
                case 1: stalfos.state = new StalfosDownMovingState(stalfos); break;
                case 2: stalfos.state = new StalfosLeftMovingState(stalfos); break;
                case 3: stalfos.state = new StalfosRightMovingState(stalfos); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, stalfos.Position);
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == upMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            stalfos.Position += deltaVector * stalfos.movingSpeed;
            sprite.Update(gameTime);
        }
    }
}
