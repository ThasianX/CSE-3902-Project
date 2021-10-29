using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGel : IEnemy, ICollidable
    {
        public IEnemyState state;
        public ISprite sprite { get; set; }
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState blueGelHealthState;
        private int immuneTime = 60;
        private int immnueTimeCounter;
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

            blueGelHealthState = new BlueGelHealthState(this, 50);
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
            sprite.Update(gameTime);
            // Enemy will not take damage every frame, only take damage when immune time is over.
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                blueGelHealthState.Update(gameTime);
                immnueTimeCounter--;
            }
            else if (Immune())
            {
                immnueTimeCounter--;
            }
        }

        // determine if player can take damage
        public bool Immune()
        {
            return immnueTimeCounter > 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
            blueGelHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                blueGelHealthState.TakeDamage(damage);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 9, 9);
        }
    }
}
