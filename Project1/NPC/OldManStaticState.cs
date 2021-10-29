using Microsoft.Xna.Framework;
using Project1.Enemy;

namespace Project1.NPC
{
    class OldManStaticState : IEnemyState
    {
        private IEnemy oldMan;

        public OldManStaticState(IEnemy oldMan)
        {
            this.oldMan = oldMan;
            oldMan.Sprite = SpriteFactory.Instance.CreateSprite("OldMan_standing");
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

        public void Update(GameTime gameTime)
        {
        }
    }

}

