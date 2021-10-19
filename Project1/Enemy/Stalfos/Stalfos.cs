using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy, ICollidable
    {
        public IEnemyState state;
        public Vector2 Position { get; set; }
        public bool isMover => true;

        public float movingSpeed;
        private int choice;
        private Random rand = new Random();
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

            // Visualize rectangle for testing
            Rectangle rectangle = GetRectangle();
            int lineWidth = 1;
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), Color.Red);
            spriteBatch.Draw(Game1.whiteRectangle, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), Color.Red);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 15, 16);
        }
    }
}
