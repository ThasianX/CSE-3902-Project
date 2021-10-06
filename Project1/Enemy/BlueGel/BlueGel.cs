using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Enemy
{
    public class BlueGel : IEnemy
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        private Vector2 startPosition;
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        //private bool isLinkNearby;

        public BlueGel(Vector2 position)
        {
            this.Position = position;
            startPosition = position;
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
            Position = startPosition;
        }
    }
}
