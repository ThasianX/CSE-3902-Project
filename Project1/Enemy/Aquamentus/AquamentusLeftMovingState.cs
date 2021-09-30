using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class AquamentusLeftMovingState : IEnemyState
    {
        private Aquamentus aquamentus;
        private IAnimation leftMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        public int cycleLength { get; }

        public AquamentusLeftMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            leftMovingAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            cycleLength = leftMovingAnimation.CycleLength;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            choice = rand.Next(1, 3);
            switch (choice)
            {
                 case 2: aquamentus.state = new AquamentusRightMovingState(aquamentus); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, aquamentus.position);
        }

        public void Update()
        {
            aquamentus.position = aquamentus.position + new Vector2(-1, 0) * aquamentus.movingSpeed;
            sprite.Update();
        }
    }
}