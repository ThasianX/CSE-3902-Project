using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class StalfosDownMovingState : IEnemyState
    {
        private IEnemy stalfos;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public StalfosDownMovingState(IEnemy stalfos)
        {
            this.stalfos = stalfos;
            stalfos.Sprite = SpriteFactory.Instance.CreateSprite("stalfos_walking");
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
                case 1: stalfos.State = new StalfosUpMovingState(stalfos); break;
                case 2: stalfos.State = new StalfosLeftMovingState(stalfos); break;
                case 3: stalfos.State = new StalfosRightMovingState(stalfos); break;
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
            stalfos.Position += deltaVector * stalfos.MovingSpeed;
        }
    }
}
