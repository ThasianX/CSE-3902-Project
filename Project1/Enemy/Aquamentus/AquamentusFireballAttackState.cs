using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Animations;
using Project1.Interfaces;
using Project1.Objects;

namespace Project1.Enemy
{
    public class AquamentusFireballAttackState : IEnemyState
    {
        private Aquamentus aquamentus;
        // Aquamentus current animation data will be determined by the direction passed in
        private IAnimation currentAnimation;
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
            currentAnimation = new AquamentusMovingAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(currentAnimation);
            fireballOne = new Fireball(aquamentus.position + new Vector2(fireballOffset, 0), new Vector2(0,-1), activeFrameCount);
            fireballTwo = new Fireball(aquamentus.position + new Vector2(fireballOffset, 0), new Vector2(0,0), activeFrameCount);
            fireballThree = new Fireball(aquamentus.position + new Vector2(fireballOffset, 0), new Vector2(0, 1), activeFrameCount);
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

        public void Update()
        {
            // When finish BoomerangAttack, change a random direction
            if (timer++ == activeFrameCount)
            {
                ChangeDirection();
            }
            fireballOne.Update();
            fireballTwo.Update();
            fireballThree.Update();
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireballOne.Draw(spriteBatch, aquamentus.position);
            fireballTwo.Draw(spriteBatch, aquamentus.position);
            fireballThree.Draw(spriteBatch, aquamentus.position);
            sprite.Draw(spriteBatch, aquamentus.position);
        }
    }
}
