using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class SpikeLeftMovingState : IEnemyState
    {
        private IEnemy spike;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public SpikeLeftMovingState(IEnemy spike)
        {
            this.spike = spike;
            spike.Sprite = SpriteFactory.Instance.CreateSprite("Spike_moving");
            timer = 0;
            currentDirection = Direction.Left;
            deltaVector = new Vector2(-1, 0);
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
                case 1: spike.State = new SpikeUpMovingState(spike); break;
                case 2: spike.State = new SpikeDownMovingState(spike); break;
                case 3: spike.State = new SpikeRightMovingState(spike); break;
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
            spike.Position += deltaVector * spike.MovingSpeed;
        }
    }
}

