using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class RedGloriyaLeftMovingState : IEnemyState
    {
        private RedGloriya redGloriya;
        // RedGloriya Left Moving animation data
        private IAnimation leftMovingAnimation;
        private ISprite sprite;
        // Left moving state, so Direction.Left
        private Direction currentDirection;
        private Vector2 deltaVector;
        private Random rand = new Random();
        private int choice;
        private int timer;

        public RedGloriyaLeftMovingState(RedGloriya redGloriya)
        {
            this.redGloriya = redGloriya;
            leftMovingAnimation = new RedGloriyaLeftMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(leftMovingAnimation);
            currentDirection = Direction.Left;
            deltaVector = new Vector2(-1, 0);
        }

        public void FireBallAttack()
        {
        }

        // Change current RedGloriya state to RedGloriyaAttackState
        public void BoomerangAttack()
        {
            redGloriya.state = new RedGloriyaBoomerangAttackState(redGloriya, currentDirection);
        }

        // Change current RedGloriya state to a random direction state.
        public void ChangeDirection()
        {
            choice = rand.Next(1, 4);
            switch (choice)
            {
                case 1: redGloriya.state = new RedGloriyaUpMovingState(redGloriya); break;
                case 2: redGloriya.state = new RedGloriyaDownMovingState(redGloriya); break;
                case 3: redGloriya.state = new RedGloriyaRightMovingState(redGloriya); break;
            }
        }

        public void Update()
        {
            // When complete an animation cycle length, make a choice
            if (timer++ == leftMovingAnimation.CycleLength)
            {
                // 1/4 chance to do a BoomerangAttack
                choice = rand.Next(4);
                if (choice == 0)
                {
                    BoomerangAttack();
                }
                // 3/4 chance to do a ChangeDirection
                else
                {
                    ChangeDirection();
                }
                timer = 0;
            }
            redGloriya.Position += deltaVector * redGloriya.movingSpeed;
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            sprite.Draw(spriteBatch, redGloriya.Position);
        }
    }
}
