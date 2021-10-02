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
        private Random rand = new Random();
        private int choice;

        public AquamentusRightMovingState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            rightMovingAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(rightMovingAnimation);
            timer = 0;
            // All direction for Aquamentus is facing left
            currentDirection = Direction.Left;
            deltaVector = new Vector2(1, 0);
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
            sprite.Draw(spriteBatch, aquamentus.position);
        }

        public void Update()
        {
            timer++;
            if (timer == rightMovingAnimation.CycleLength)
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
            aquamentus.position += deltaVector * aquamentus.movingSpeed;
            sprite.Update();
        }
    }
}
