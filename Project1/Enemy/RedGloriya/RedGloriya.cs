﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Enemy
{
    public class RedGloriya : IEnemy, ICollidable
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float MovingSpeed { get; set; }
        private int choice;
        private Random rand = new Random();
        public bool IsMover => true;
        public string CollisionType => "Enemy";
        public IHealthState redGloriyaHealthState;

        public RedGloriya(Vector2 position)
        {
            this.Position = position;
            choice = rand.Next(4);
            // When initialize, choose a random direction
            switch (choice)
            {
                case 0:
                    State = new RedGloriyaUpMovingState(this);
                    break;
                case 1:
                    State = new RedGloriyaDownMovingState(this);
                    break;
                case 2:
                    State = new RedGloriyaRightMovingState(this);
                    break;
                case 3:
                    State = new RedGloriyaLeftMovingState(this);
                    break;
            }

            MovingSpeed = 1f;
            redGloriyaHealthState = new RedGloriyaHealthState(this, 2);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
            State.BoomerangAttack();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }


        public void Update(GameTime gameTime)
        {
            // Update the current state
            // Possible state: direction, attack
            if (!DeadEnemy())
            {
                State.Update(gameTime);
                Sprite.Update(gameTime);
                redGloriyaHealthState.Update(gameTime);
            }
            else
            {
                KillEnemy();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
            redGloriyaHealthState.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            redGloriyaHealthState.Draw(spriteBatch);
        }

        public void TakeDamage(int damage)
        {
            redGloriyaHealthState.TakeDamage(damage);
            SoundManager.Instance.PlaySound("EnemyHit");
            if (!DeadEnemy())
            {
                GameObjectManager.Instance.AddOnNextFrame(new DamagedEnemy(this));
                GameObjectManager.Instance.RemoveOnNextFrame(this);
            }
        }

        public bool DeadEnemy()
        {
            return redGloriyaHealthState.health <= 0;
        }

        public void KillEnemy()
        {
            LevelManager.Instance.GetCurrentRoom().RemoveObject(this);
            GameObjectManager.Instance.RemoveOnNextFrame(this);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 14, 16);
        }
    }
}
