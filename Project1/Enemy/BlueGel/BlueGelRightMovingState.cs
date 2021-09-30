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
        public int cycleLength { get; }

        public BlueGelRightMovingState(BlueGel blueGel)
        {
            this.blueGel = blueGel;
            rightMovingAnimation = new BlueGelMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            cycleLength = rightMovingAnimation.CycleLength;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueGel.position);
        }

        public void Update()
        {
            blueGel.position = blueGel.position + new Vector2(1, 0) * blueGel.movingSpeed;
            sprite.Update();
        }
    }
}
