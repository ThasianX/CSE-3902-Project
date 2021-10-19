using Microsoft.Xna.Framework.Graphics;
using Project1.Interfaces;

namespace Project1.Enemy
{
    public interface IEnemy : IGameObject
    {
        public void FireBallAttack();
        public void BoomerangAttack();
        public void ChangeDirection();
    }
}
