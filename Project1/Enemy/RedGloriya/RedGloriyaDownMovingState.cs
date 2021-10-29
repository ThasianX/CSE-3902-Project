using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class RedGloriyaDownMovingState : IEnemyState
    {
        private IEnemy redGloriya;
        // Down moving state, so Direction.Down
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;
        private int counter;

        public RedGloriyaDownMovingState(IEnemy redGloriya)
        {
            this.redGloriya = redGloriya;
            redGloriya.Sprite = SpriteFactory.Instance.CreateSprite("RedGloriya_walking_down");
            currentDirection = Direction.Down;
            deltaVector = new Vector2(0, 1);
            counter = 30;
        }

        public void FireBallAttack()
        {
        }

        // Change current RedGloriya state to RedGloriyaAttackState
        public void BoomerangAttack()
        {
            redGloriya.State = new RedGloriyaBoomerangAttackState(redGloriya, currentDirection);
        }

        // Change current RedGloriya state to a random direction state.
        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: redGloriya.State = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.State = new RedGloriyaLeftMovingState(redGloriya); break;
                case 3: redGloriya.State = new RedGloriyaRightMovingState(redGloriya); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When complete an animation cycle length, make a choice
            if (timer++ == counter)
            {
                // 1/4 chance to do a BoomerangAttack
                choice = rand.Next(4);
                if (choice == 0)
                {
                    BoomerangAttack();
                }
                // 3/4 chance to do a ChangeDirection
                else
                {
                    ChangeDirection();
                }
                timer = 0;
            }
            redGloriya.Position += deltaVector * redGloriya.MovingSpeed;
        }
    }
}
