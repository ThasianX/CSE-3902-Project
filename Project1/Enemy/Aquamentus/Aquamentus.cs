using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class Aquamentus : IEnemy
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        //private bool isLinkNearby;

        public Aquamentus(Vector2 position)
        {
            this.Position = position;
            startPosition = position;
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

        // Only need this for Sprint 2
        public void ResetPosition()
        {
            Position = startPosition;
        }
    }
}
