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
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public AquamentusLeftMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            leftMovingAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            timer = 0;
            currentDirection = Direction.Left;
            deltaVector = new Vector2(-1, 0);
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
        public void Update()
        {
            timer++;
            if (timer == leftMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            aquamentus.position += deltaVector * aquamentus.movingSpeed;
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, aquamentus.position);
        }
    }
}