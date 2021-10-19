using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project1.Animations;
using Project1.Interfaces;
using Project1.Enemy;

namespace Project1.NPC
{
    class OldManStaticState : IEnemyState
    {
        private OldMan oldMan;
        private IAnimation oldManStillAnimation;
        private ISprite sprite;

        public OldManStaticState(OldMan oldMan)
        {
            this.oldMan = oldMan;
            oldManStillAnimation = new OldManStillAnimation();
            sprite = SpriteFactory.Instance.CreateSprite("OldMan_standing");
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
            sprite.Draw(spriteBatch, oldMan.Position);
        }

        public void Update(GameTime gameTime)
        {
        }
    }

}

