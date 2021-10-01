using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class BlueGel : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        private int timer;
        //private bool isLinkNearby;

        public BlueGel(Vector2 position)
        {
            this.position = position;
            startPosition = position;
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    state = new BlueGelUpMovingState(this);
                    break;
                case 1:
                    state = new BlueGelDownMovingState(this);
                    break;
                case 2:
                    state = new BlueGelRightMovingState(this);
                    break;
                case 3:
                    state = new BlueGelLeftMovingState(this);
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
