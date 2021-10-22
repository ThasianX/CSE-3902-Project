using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBat : IEnemy, ICollidable
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState blueBatHealthState;
        private int immuneTime = 60;
        private int immnueTimeCounter;
        //private bool isLinkNearby;

        public BlueBat(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    state = new BlueBatUpMovingState(this);
                    break;
                case 1:
                    state = new BlueBatDownMovingState(this);
                    break;
                case 2:
                    state = new BlueBatRightMovingState(this);
                    break;
                case 3:
                    state = new BlueBatLeftMovingState(this);
                    break;
            }

            movingSpeed = 1f;
            blueBatHealthState = new BlueBatHealthState(this, 50);
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
            // Possible state: direction, fireball attack
            state.Update(gameTime);
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                blueBatHealthState.Update(gameTime);
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
            blueBatHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                blueBatHealthState.TakeDamage(damage);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 12, 10);
        }
    }
}