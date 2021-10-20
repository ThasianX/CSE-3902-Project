using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriya : IEnemy, ICollidable
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool isMover => true;
        public IHealthState redGloriyaHealthState;
        //private bool isLinkNearby;

        public RedGloriya(Vector2 position)
        {
            this.Position = position;
            choice = rand.Next(4);
            // When initialize, choose a random direction
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
            redGloriyaHealthState = new RedGloriyaHealthState(this, 100);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
            state.BoomerangAttack();
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }


        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, attack
            state.Update(gameTime);
            redGloriyaHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            redGloriyaHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            redGloriyaHealthState.TakeDamage(damage);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 14, 16);
        }
    }
}
