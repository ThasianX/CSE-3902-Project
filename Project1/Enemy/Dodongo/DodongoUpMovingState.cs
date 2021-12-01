using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class DodongoUpMovingState : IEnemyState
    {
        private IEnemy dodongo;
        // Up moving state, so Direction.Up
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;
        private int counter;

        public DodongoUpMovingState(IEnemy dodongo)
        {
            this.dodongo = dodongo;
            dodongo.Sprite = SpriteFactory.Instance.CreateSprite("Dodongo_walking_up");
            currentDirection = Direction.Up;
            deltaVector = new Vector2(0, -1);
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
                case 1: dodongo.State = new DodongoDownMovingState(dodongo); break;
                case 2: dodongo.State = new DodongoLeftMovingState(dodongo); break;
                case 3: dodongo.State = new DodongoRightMovingState(dodongo); break;
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

