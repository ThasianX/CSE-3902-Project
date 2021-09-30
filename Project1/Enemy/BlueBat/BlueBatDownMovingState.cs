using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBatDownMovingState : IEnemyState
    {
        private BlueBat blueBat;
        private IAnimation downMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        public int cycleLength { get; }

        public BlueBatDownMovingState(BlueBat blueBat)
        {
            this.blueBat = blueBat;
            downMovingAnimation = new BlueBatMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(downMovingAnimation);
            cycleLength = downMovingAnimation.CycleLength;
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
                case 1: blueBat.state = new BlueBatUpMovingState(blueBat); break;
                case 2: blueBat.state = new BlueBatLeftMovingState(blueBat); break;
                case 3: blueBat.state = new BlueBatRightMovingState(blueBat); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueBat.position);
        }

        public void Update()
        {
            blueBat.position += new Vector2(0, 1) * blueBat.movingSpeed;
            sprite.Update();
        }
    }
}
