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
        private Direction currentDirection;
        public int cycleLength { get; }

        public AquamentusLeftMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            leftMovingAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            cycleLength = leftMovingAnimation.CycleLength;
            currentDirection = Direction.Left;
        }

        public void FireBallAttack()
        {
            // need implementation
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            aquamentus.state = new AquamentusRightMovingState(aquamentus);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, aquamentus.position);
        }

        public void Update()
        {
            aquamentus.position += new Vector2(-1, 0) * aquamentus.movingSpeed;
            sprite.Update();
        }
    }
}