using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBat : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        public LootTable LootTable { get; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState blueBatHealthState;
        public BlueBat(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    State = new BlueBatUpMovingState(this);
                    break;
                case 1:
                    State = new BlueBatDownMovingState(this);
                    break;
                case 2:
                    State = new BlueBatRightMovingState(this);
                    break;
                case 3:
                    State = new BlueBatLeftMovingState(this);
                    break;
            }
            MovingSpeed = 1f;
            blueBatHealthState = new BlueBatHealthState(this, 1);
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


        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, fireball attack
            GameObjectDeletionManager.Instance.EnemyDeletionCheck(this, blueBatHealthState);
            State.Update(gameTime);
            Sprite.Update(gameTime);
            blueBatHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            blueBatHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            blueBatHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            blueBatHealthState.TakeDamage(damage);
            if (blueBatHealthState.health > 0)
            {
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
            return new Rectangle((int)Position.X, (int)Position.Y, 12, 10);
        }
    }
}