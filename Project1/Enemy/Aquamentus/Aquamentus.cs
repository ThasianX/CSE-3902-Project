using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class Aquamentus : IEnemy, ICollidable
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool isMover => true;
        //private bool isLinkNearby;

        public Aquamentus(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(2);
            switch (choice)
            {
                case 0:
                    state = new AquamentusRightMovingState(this);
                    break;
                case 1:
                    state = new AquamentusLeftMovingState(this);
                    break;
            }

            movingSpeed = 1f;
        }

        public void FireBallAttack()
        {
            state.FireBallAttack();
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
            // Possible state: direction, fireball attack
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 24, 32);
        }

    }
}
