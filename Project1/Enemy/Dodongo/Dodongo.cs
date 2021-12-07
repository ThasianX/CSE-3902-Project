using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class Dodongo : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        public LootTable LootTable { get; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public bool isFreeze { get; set; }
        private float freezeTime;
        public string CollisionType => "Enemy";
        public IHealthState dodongoHealthState;

        public Dodongo(Vector2 position)
        {
            this.Position = position;
            choice = rand.Next(4);
            // When initialize, choose a random direction
            switch (choice)
            {
                case 0:
                    State = new DodongoUpMovingState(this);
                    break;
                case 1:
                    State = new DodongoDownMovingState(this);
                    break;
                case 2:
                    State = new DodongoRightMovingState(this);
                    break;
                case 3:
                    State = new DodongoLeftMovingState(this);
                    break;
            }

            MovingSpeed = 0.8f;
            dodongoHealthState = new DodongoHealthState(this, 2);
            LootTable = new DefaultLootTable();
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

        public void Freeze(float freezeTime)
        {
            if (this.freezeTime < freezeTime)
            {
                this.freezeTime = freezeTime;
            }
            isFreeze = true;
        }

        public void Defreeze(GameTime gameTime)
        {
            freezeTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (freezeTime <= 0)
            {
                isFreeze = false;
            }
        }
        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, attack
            GameObjectDeletionManager.Instance.EnemyDeletionCheck(this, dodongoHealthState);
            if (!isFreeze)
            {
                State.Update(gameTime);
                Sprite.Update(gameTime);
            }
            else
            {
                Defreeze(gameTime);
            }
            dodongoHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            dodongoHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            dodongoHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            dodongoHealthState.TakeDamage(damage);
            if (dodongoHealthState.health > 0)
            {
                Freeze(Constants.stunTime);
                SoundManager.Instance.PlaySound("EnemyHit");
                GameObjectManager.Instance.AddOnNextFrame(new DamagedEnemy(this));
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
            else
            {
                SoundManager.Instance.PlaySound("EnemyDie");
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 14, 16);
        }
    }
}

