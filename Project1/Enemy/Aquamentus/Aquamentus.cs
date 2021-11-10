using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class Aquamentus : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState aquamentusHealthState;

        public Aquamentus(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(2);
            switch (choice)
            {
                case 0:
                    State = new AquamentusRightMovingState(this);
                    break;
                case 1:
                    State = new AquamentusLeftMovingState(this);
                    break;
            }

            MovingSpeed = 1f;

            aquamentusHealthState = new AquamentusHealthState(this, 8);
        }

        public void FireBallAttack()
        {
            State.FireBallAttack();
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, fireball attack
            if (!DeadEnemy())
            {
                State.Update(gameTime);
                Sprite.Update(gameTime);
                aquamentusHealthState.Update(gameTime);
            }
            else
            {
                KillEnemy();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            aquamentusHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            aquamentusHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            aquamentusHealthState.TakeDamage(damage);
            SoundManager.Instance.PlaySound("EnemyHit");
            if (!DeadEnemy())
            {
                GameObjectManager.Instance.AddOnNextFrame(new DamagedEnemy(this));
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
        }

        public bool DeadEnemy()
        {
            return aquamentusHealthState.health <= 0;
        }

        public void KillEnemy()
        {
            LevelManager.Instance.GetCurrentRoom().RemoveObject(this);
            GameObjectManager.Instance.RemoveOnNextFrame(this);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 24, 32);
        }

    }
}
