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
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState aquamentusHealthState;
        private int immuneTime = 60;
        private int immnueTimeCounter;
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

            aquamentusHealthState = new AquamentusHealthState(this, 300);
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
            // When damage taked, update only after the immune time is passed
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                aquamentusHealthState.Update(gameTime);
                immnueTimeCounter--;
            }
            else if (Immune())
            {
                immnueTimeCounter--;
            }
        }

        // determine if enemy can take damage
        public bool Immune()
        {
            return immnueTimeCounter > 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            aquamentusHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                aquamentusHealthState.TakeDamage(damage);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 24, 32);
        }

    }
}
