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
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public AquamentusRightMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            rightMovingAnimation = new AquamentusMovingAnimation();
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
            aquamentus.state = new AquamentusLeftMovingState(aquamentus);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, aquamentus.position);
        }

        public void Update()
        {
            timer++;
            if (timer == rightMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            aquamentus.position += deltaVector * aquamentus.movingSpeed;
            sprite.Update();
        }
    }
}
