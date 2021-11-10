using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.Enemy
{
    public class AquamentusFireballAttackState : IEnemyState
    {
        private IEnemy aquamentus;
        // The Fireball instance used for Update and Draw
        private IProjectile fireballOne;
        private IProjectile fireballTwo;
        private IProjectile fireballThree;
        // Not sure, need to ask Keenan !!
        private int fireballOffset = 8;
        // The length of animation frame boomerang will Update, also Not sure, need to ask Keenan !!
        private int activeFrameCount = 50;
        private int choice;
        private int timer;
        private Random rand = new Random();
        private float cosAmount = 0.154f;

        public AquamentusFireballAttackState(IEnemy aquamentus)
        {
            this.aquamentus = aquamentus;
            aquamentus.Sprite = SpriteFactory.Instance.CreateSprite("aquamentus_walking");
            fireballOne = new Fireball(aquamentus.Position + new Vector2(fireballOffset, fireballOffset), new Vector2(0, -cosAmount), activeFrameCount, aquamentus);
            fireballTwo = new Fireball(aquamentus.Position + new Vector2(fireballOffset, fireballOffset), new Vector2(0,0), activeFrameCount, aquamentus);
            fireballThree = new Fireball(aquamentus.Position + new Vector2(fireballOffset, fireballOffset), new Vector2(0, cosAmount), activeFrameCount, aquamentus);

            GameObjectManager.Instance.AddOnNextFrame(fireballOne);
            GameObjectManager.Instance.AddOnNextFrame(fireballTwo);
            GameObjectManager.Instance.AddOnNextFrame(fireballThree);
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            choice = rand.Next(2);
            switch (choice)
            {
                case 0: aquamentus.State = new AquamentusLeftMovingState(aquamentus); break;
                case 1: aquamentus.State = new AquamentusRightMovingState(aquamentus); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When finish BoomerangAttack, change a random direction
            if (timer++ == activeFrameCount)
            {
                ChangeDirection();
            }
        }
    }
}
