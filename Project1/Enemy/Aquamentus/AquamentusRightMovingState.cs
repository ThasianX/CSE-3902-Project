using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class AquamentusRightMovingState : IEnemyState
    {
        private Aquamentus aquamentus;
        private IAnimation rightMovingAnimation;
        private ISprite sprite;
        private Direction currentDirection;
        public int cycleLength { get; }

        public AquamentusRightMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            rightMovingAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            cycleLength = rightMovingAnimation.CycleLength;
            currentDirection = Direction.Right;
        }

        public void FireBallAttack()
        {
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
            sprite.Draw(spriteBatch, aquamentus.position);
        }

        public void Update()
        {
            aquamentus.position = aquamentus.position + new Vector2(1, 0) * aquamentus.movingSpeed;
            sprite.Update();
        }
    }
}
