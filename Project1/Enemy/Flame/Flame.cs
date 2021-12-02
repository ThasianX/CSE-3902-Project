using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class Flame : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        private bool isFreeze;
        private float freezeTime;
        public string CollisionType => "Enemy";

        public Flame(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    State = new FlameUpMovingState(this);
                    break;
                case 1:
                    State = new FlameDownMovingState(this);
                    break;
                case 2:
                    State = new FlameRightMovingState(this);
                    break;
                case 3:
                    State = new FlameLeftMovingState(this);
                    break;
            }
            MovingSpeed = 1f;
            freezeTime = 3f;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Freeze()
        {
            freezeTime = 3f;
            isFreeze = true;
        }

        private void Defreeze(GameTime gameTime)
        {
            freezeTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (freezeTime <= 0)
            {
                isFreeze = false;
            }
        }

        public void Update(GameTime gameTime)
        {

            if (!isFreeze)
            {
                State.Update(gameTime);
                Sprite.Update(gameTime);
            }
            else
            {
                Defreeze(gameTime);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);

        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);

        }

        public void TakeDamage(int damage)
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 9, 9);
        }
    }
}
