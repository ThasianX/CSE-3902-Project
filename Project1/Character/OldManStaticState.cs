using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;
using Project1.Enemy;

namespace Project1.Character
{
    class OldManStaticState : IEnemyState
    {
        private OldMan oldMan;
        private IAnimation oldManStillAnimation;
        private ISprite sprite;
        private int choice;
        private Random rand = new Random();
        public int cycleLength { get; }

        public OldManStaticState(OldMan oldMan)
        {
            this.oldMan = oldMan;
            oldManStillAnimation = new OldManStillAnimation();
            sprite = SpriteFactory.Instance.CreateAnimatedSprite(oldManStillAnimation);
            cycleLength = oldManStillAnimation.CycleLength;
        }

        public void FireBallAttack()
        {
        }

        public void BoomerangAttack()
        {
        }

        public void ChangeDirection()
        {
            
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, oldMan.position);
        }

        public void Update()
        {
            oldMan.position = oldMan.position + new Vector2(0, 1) * oldMan.movingSpeed;
            sprite.Update();
        }
    }

}

