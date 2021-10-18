using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class RedGloriya : IEnemy
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        //private bool isLinkNearby;

        public RedGloriya(Vector2 position)
        {
            this.Position = position;
            startPosition = position;
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
        }

        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, attack
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        // Only need this for Sprint 2
        public void ResetPosition()
        {
            Position = startPosition;
        }
    }
}
