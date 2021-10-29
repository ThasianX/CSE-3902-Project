using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy, ICollidable
    {
        public IEnemyState state;
        public ISprite sprite { get; set; }
        public Vector2 Position { get; set; }
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
        public IHealthState stalfosHealthState;
        private int immuneTime = 60;
        private int immnueTimeCounter;
        //private bool isLinkNearby;

        public Stalfos(Vector2 position)
        {
            this.Position = position;
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
            stalfosHealthState = new StalfosHealthState(this, 100);
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
            // If the enemy is in immune state, its health state do not need to update.
            if (Immune() && immnueTimeCounter == immuneTime)
            {
                stalfosHealthState.Update(gameTime);
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
            stalfosHealthState.Draw(spriteBatch);

            //DrawRectangle(spriteBatch)
        }

        private void DrawRectangle(SpriteBatch spriteBatch)
        {
            // Visualize rectangle for testing
            Rectangle rectangle = GetRectangle();
            int lineWidth = 1;
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), Color.Red);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                stalfosHealthState.TakeDamage(damage);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 15, 16);
        }
    }
}
