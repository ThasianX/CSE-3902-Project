using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueGelRightMovingState : IEnemyState
    {
        private BlueGel blueGel;
        private IAnimation rightMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public BlueGelRightMovingState(BlueGel blueGel)
        {
            this.blueGel = blueGel;
            rightMovingAnimation = new BlueGelMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            timer = 0;
            currentDirection = Direction.Right;
            deltaVector = new Vector2(1, 0);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: blueGel.state = new BlueGelUpMovingState(blueGel); break;
                case 2: blueGel.state = new BlueGelDownMovingState(blueGel); break;
                case 3: blueGel.state = new BlueGelLeftMovingState(blueGel); break;
            }
        }
        public void Update()
        {
            timer++;
            if (timer == rightMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            blueGel.Position += deltaVector * blueGel.movingSpeed;
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueGel.Position);
        }
    }
}
