using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy
    {
        public IEnemyState state;
        public Vector2 position;
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        //private bool isLinkNearby;

        public Stalfos(Vector2 position)
        {
            this.position = position;
            startPosition = position;
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
        }

        public void Update()
        {
            // Update the current state
            // Possible state: direction
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        // Only need this for Sprint 2
        public void ResetPosition()
        {
            position = startPosition;
        }
    }
}
