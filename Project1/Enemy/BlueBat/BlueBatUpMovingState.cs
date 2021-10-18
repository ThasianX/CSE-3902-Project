using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public class BlueBatUpMovingState : IEnemyState
    {
        private BlueBat blueBat;
        private IAnimation upMovingAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;

        public BlueBatUpMovingState(BlueBat blueBat)
        {
            this.blueBat = blueBat;
            upMovingAnimation = new BlueBatMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(upMovingAnimation);
            timer = 0;
            currentDirection = Direction.Up;
            deltaVector = new Vector2(0, -1);
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
                case 1: blueBat.state = new BlueBatDownMovingState(blueBat); break;
                case 2: blueBat.state = new BlueBatLeftMovingState(blueBat); break;
                case 3: blueBat.state = new BlueBatRightMovingState(blueBat); break;
            }
        }
        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == upMovingAnimation.CycleLength)
            {
                ChangeDirection();
                timer = 0;
            }
            blueBat.Position += deltaVector * blueBat.movingSpeed;
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, blueBat.Position);
        }
    }
}

