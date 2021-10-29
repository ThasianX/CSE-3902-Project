using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriya : IEnemy, ICollidable
    {
        public IEnemyState state;
        public ISprite sprite { get; set; }
        public Vector2 Position { get; set; }
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState redGloriyaHealthState;
        private int immuneTime = 60;
        private int immnueTimeCounter;
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
            sprite.Update(gameTime);
            // Enemy health state only update when its immune time is over. 
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                redGloriyaHealthState.Update(gameTime);
                immnueTimeCounter--;
            }
            else if (Immune())
            {
                immnueTimeCounter--;
            }
        }

        public bool Immune()
        {
            return immnueTimeCounter > 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
            redGloriyaHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                redGloriyaHealthState.TakeDamage(damage);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 14, 16);
        }
    }
}
