using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        private int timer;
        private bool isLinkNearby;

        public Stalfos(Vector2 position)
        {
            this.position = position;
            choice = rand.Next(4);
            switch (choice)
            {
                case 0: state = new StalfosUpMovingState(this); break;
                case 1: state = new StalfosDownMovingState(this); break;
                case 2: state = new StalfosRightMovingState(this); break;
                case 3: state = new StalfosLeftMovingState(this); break;
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

        public void FireBallAttack()
        {
           state.FireBallAttack();
        }

        public void BoomerangAttack()
        {
            state.BoomerangAttack();
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }
    }
}
