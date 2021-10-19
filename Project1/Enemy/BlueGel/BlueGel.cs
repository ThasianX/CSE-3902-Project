using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGel : IEnemy, ICollidable
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool isMover => true;
        //private bool isLinkNearby;

        public BlueGel(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 9, 9);
        }
    }
}
