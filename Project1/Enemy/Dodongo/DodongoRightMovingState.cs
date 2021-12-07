using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class DodongoRightMovingState : IEnemyState
    {
        private IEnemy dodongo;
        // Right moving state, so Direction.Right
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;
        private int counter;

        public DodongoRightMovingState(IEnemy dodongo)
        {
            this.dodongo = dodongo;
            dodongo.Sprite = SpriteFactory.Instance.CreateSprite("Dodongo_walking_right");
            currentDirection = Direction.Right;
            deltaVector = new Vector2(1, 0);
            counter = 30;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        // Change current dodongo state to a random direction state.
        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: dodongo.State = new DodongoUpMovingState(dodongo); break;
                case 2: dodongo.State = new DodongoDownMovingState(dodongo); break;
                case 3: dodongo.State = new DodongoLeftMovingState(dodongo); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When complete an animation cycle length, make a choice
            if (timer++ == counter)
            {

                ChangeDirection();

                timer = 0;
            }
            dodongo.Position += deltaVector * dodongo.MovingSpeed;
        }
    }
}

