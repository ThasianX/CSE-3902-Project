using System;
using Microsoft.Xna.Framework;

namespace Project1.Enemy
{
    public class BlueGelUpMovingState : IEnemyState
    {
        private IEnemy blueGel;
        private int choice;
        private Random rand = new Random();
        private int timer;
        // Could later used to assemble all the direction moving state
        private Direction currentDirection;
        private Vector2 deltaVector;
        private int counter;

        public BlueGelUpMovingState(IEnemy blueGel)
        {
            this.blueGel = blueGel;
            blueGel.Sprite = SpriteFactory.Instance.CreateSprite("BlueGel_walking");
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
                case 1: blueGel.State = new BlueGelDownMovingState(blueGel); break;
                case 2: blueGel.State = new BlueGelLeftMovingState(blueGel); break;
                case 3: blueGel.State = new BlueGelRightMovingState(blueGel); break;
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
            blueGel.Position += deltaVector * blueGel.MovingSpeed;
        }
    }
}
