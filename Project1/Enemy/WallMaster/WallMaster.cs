﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class WallMaster : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        private bool isFreeze;
        public string CollisionType => "Enemy";
        public IHealthState wallMasterHealthState;

        public WallMaster(Vector2 position)
        {
            this.Position = position;
            // When initialize, choose a random direction
            choice = rand.Next(4);
            switch (choice)
            {
                case 0:
                    State = new WallMasterUpMovingState(this);
                    break;
                case 1:
                    State = new WallMasterDownMovingState(this);
                    break;
                case 2:
                    State = new WallMasterRightMovingState(this);
                    break;
                case 3:
                    State = new WallMasterLeftMovingState(this);
                    break;
            }

            MovingSpeed = 1f;
            wallMasterHealthState = new WallMasterHealthState(this, 1);
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
            isFreeze = true;
        }

        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, fireball attack
            GameObjectDeletionManager.Instance.EnemyDeletionCheck(this, wallMasterHealthState);
            State.Update(gameTime);
            Sprite.Update(gameTime);
            wallMasterHealthState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            wallMasterHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            wallMasterHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            wallMasterHealthState.TakeDamage(damage);
            if (wallMasterHealthState.health > 0)
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
