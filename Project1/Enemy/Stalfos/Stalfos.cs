using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class Stalfos : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        public LootTable LootTable { get; }
        public bool IsMover => true;
        public bool isFreeze { get; set; }
        private float freezeTime;

        public string CollisionType => "Enemy";
        private int choice;
        private Random rand = new Random();
        public IHealthState stalfosHealthState;
        public Stalfos(Vector2 position)
        {
            this.Position = position;
            choice = rand.Next(4);
            // When initialize, choose a random direction
            switch (choice)
            {
                case 0: State = new StalfosUpMovingState(this); break;
                case 1: State = new StalfosDownMovingState(this); break;
                case 2: State = new StalfosRightMovingState(this); break;
                case 3: State = new StalfosLeftMovingState(this); break;
            }
            MovingSpeed = 0.7f;
            stalfosHealthState = new StalfosHealthState(this, 2);
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
            // Possible state: direction
            GameObjectDeletionManager.Instance.EnemyDeletionCheck(this, stalfosHealthState);
            if (!isFreeze)
            {
                State.Update(gameTime);
                Sprite.Update(gameTime);
            }
            else
            {
                Defreeze(gameTime);
            }
            stalfosHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            stalfosHealthState.Draw(spriteBatch);

            //DrawRectangle(spriteBatch)
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
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
            stalfosHealthState.TakeDamage(damage);
            if (stalfosHealthState.health > 0)
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
            return new Rectangle((int)Position.X, (int)Position.Y, 15, 16);
        }
    }
}
