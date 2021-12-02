using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class SnakeLeftMovingState : IEnemyState
    {
        private IEnemy snake;
        // Left moving state, so Direction.Left
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;
        private int counter;

        public SnakeLeftMovingState(IEnemy snake)
        {
            this.snake = snake;
            snake.Sprite = SpriteFactory.Instance.CreateSprite("Snake_walking_left");
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

        // Change current snake state to a random direction state.
        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: snake.State = new SnakeUpMovingState(snake); break;
                case 2: snake.State = new SnakeDownMovingState(snake); break;
                case 3: snake.State = new SnakeRightMovingState(snake); break;
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
            snake.Position += deltaVector * snake.MovingSpeed;
        }
    }
}

