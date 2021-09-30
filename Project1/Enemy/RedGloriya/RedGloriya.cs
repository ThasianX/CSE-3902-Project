using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class RedGloriya : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        private int timer;
        //private bool isLinkNearby;

        public RedGloriya(Vector2 position)
        {
            this.position = position;
            startPosition = position;
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    state = new RedGloriyaUpMovingState(this);
                    break;
                case 1:
                    state = new RedGloriyaDownMovingState(this);
                    break;
                case 2:
                    state = new RedGloriyaRightMovingState(this);
                    break;
                case 3:
                    state = new RedGloriyaLeftMovingState(this);
                    break;
            }

            movingSpeed = 1f;
            timer = 0;
        }

        public void Update()
        {
            timer++;
            if (timer == state.cycleLength)
            {
                ChangeDirection();
                timer = 0;
            }

            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void BoomerangAttack()
        {
            state.BoomerangAttack();
        }

        public void ResetPosition()
        {
            position = startPosition;
        }
    }
}
