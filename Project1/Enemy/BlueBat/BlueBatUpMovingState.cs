using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class BlueBatUpMovingState : IEnemyState
    {
        private IEnemy blueBat;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public BlueBatUpMovingState(IEnemy blueBat)
        {
            this.blueBat = blueBat;
            blueBat.Sprite = SpriteFactory.Instance.CreateSprite("BlueBat_woving");
            timer = 0;
            currentDirection = Direction.Up;
            deltaVector = new Vector2(0, -1);
            counter = 30;
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
                case 1: blueBat.State = new BlueBatDownMovingState(blueBat); break;
                case 2: blueBat.State = new BlueBatLeftMovingState(blueBat); break;
                case 3: blueBat.State = new BlueBatRightMovingState(blueBat); break;
            }
        }
        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer == counter)
            {
                ChangeDirection();
                timer = 0;
            }
            blueBat.Position += deltaVector * blueBat.MovingSpeed;
        }
    }
}

