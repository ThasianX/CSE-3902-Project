using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.Enemy
{
    public class AquamentusFireballAttackState : IEnemyState
    {
        private Aquamentus aquamentus;
        private ISprite sprite;
        // The Fireball instance used for Update and Draw
        private Fireball fireballOne;
        private Fireball fireballTwo;
        private Fireball fireballThree;
        // Not sure, need to ask Keenan !!
        private int fireballOffset = 8;
        // The length of animation frame boomerang will Update, also Not sure, need to ask Keenan !!
        private int activeFrameCount = 50;
        private int choice;
        private int timer;
        private Random rand = new Random();

        public AquamentusFireballAttackState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            sprite = SpriteFactory.Instance.CreateSprite("aquamentus_walking");
            fireballOne = new Fireball(aquamentus.Position + new Vector2(fireballOffset, 0), new Vector2(0,-1), activeFrameCount);
            fireballTwo = new Fireball(aquamentus.Position + new Vector2(fireballOffset, 0), new Vector2(0,0), activeFrameCount);
            fireballThree = new Fireball(aquamentus.Position + new Vector2(fireballOffset, 0), new Vector2(0, 1), activeFrameCount);
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
                case 0: aquamentus.state = new AquamentusLeftMovingState(aquamentus); break;
                case 1: aquamentus.state = new AquamentusRightMovingState(aquamentus); break;
            }
        }

        public void Update(GameTime gameTime)
        {
            // When finish BoomerangAttack, change a random direction
            if (timer++ == activeFrameCount)
            {
                ChangeDirection();
            }
            fireballOne.Update(gameTime);
            fireballTwo.Update(gameTime);
            fireballThree.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireballOne.Draw(spriteBatch);
            fireballTwo.Draw(spriteBatch);
            fireballThree.Draw(spriteBatch);
            sprite.Draw(spriteBatch, aquamentus.Position);
        }
    }
}
