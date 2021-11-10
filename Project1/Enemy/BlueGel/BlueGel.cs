using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGel : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState blueGelHealthState;
        private int immuneTime = 30;
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
                    State = new BlueGelUpMovingState(this);
                    break;
                case 1:
                    State = new BlueGelDownMovingState(this);
                    break;
                case 2:
                    State = new BlueGelRightMovingState(this);
                    break;
                case 3:
                    State = new BlueGelLeftMovingState(this);
                    break;
            }
            MovingSpeed = 1f;

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
            State.ChangeDirection();
        }


        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction
            State.Update(gameTime);
            Sprite.Update(gameTime);
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
            Sprite.Draw(spriteBatch, Position);
            blueGelHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            blueGelHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            if (!Immune())
            {
                immnueTimeCounter = immuneTime;
                blueGelHealthState.TakeDamage(damage);
                SoundManager.Instance.PlaySound("EnemyHit");
                GameObjectManager.Instance.AddOnNextFrame(new DamagedEnemy(this));
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 9, 9);
        }
    }
}
