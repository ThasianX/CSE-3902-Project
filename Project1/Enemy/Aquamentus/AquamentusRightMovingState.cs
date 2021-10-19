﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class AquamentusRightMovingState : IEnemyState
    {
        private Aquamentus aquamentus;
        private ISprite sprite;
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int counter;

        public AquamentusRightMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            sprite = SpriteFactory.Instance.CreateSprite("aquamentus_walking");
            // All direction for Aquamentus is facing left
            currentDirection = Direction.Left;
            deltaVector = new Vector2(1, 0);
            counter = 30;
        }

        public void FireBallAttack()
        {
            aquamentus.state = new AquamentusFireballAttackState(aquamentus);
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            aquamentus.state = new AquamentusLeftMovingState(aquamentus);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, aquamentus.Position);
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == counter)
            {
                // 1/3 chance to do a FireBallAttack
                choice = rand.Next(3);
                if (choice == 0)
                {
                    FireBallAttack();
                }
                // 2/3 chance to do a ChangeDirection
                else
                {
                    ChangeDirection();
                }
                timer = 0;
            }
            aquamentus.Position += deltaVector * aquamentus.movingSpeed;
            sprite.Update(gameTime);
        }
    }
}
