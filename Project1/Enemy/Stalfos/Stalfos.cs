using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public IHealthState stalfosHealthState;
        //private bool isLinkNearby;

        public Stalfos(Vector2 position)
        {
            this.Position = position;
            choice = rand.Next(4);
            // When initialize, choose a random direction
            switch (choice)
            {
                case 0: state = new StalfosUpMovingState(this); break;
                case 1: state = new StalfosDownMovingState(this); break;
                case 2: state = new StalfosRightMovingState(this); break;
                case 3: state = new StalfosLeftMovingState(this); break;
            }
            movingSpeed = 1f;
            stalfosHealthState = new StalfosHealthState(this, 100);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction
            state.Update(gameTime);
            stalfosHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            stalfosHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            stalfosHealthState.TakeDamage(damage);
        }
    }
}
