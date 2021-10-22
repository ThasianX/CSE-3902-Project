using Project1.Interfaces;

namespace Project1.Enemy
{
    public interface IEnemy : IGameObject
    {
        public void FireBallAttack();
        public void BoomerangAttack();
        public void ChangeDirection();
        public void TakeDamage(int damage);

        /*
         * Return true if the enemy is in immune state. 
         * During immune time, enemy do not take any damage. 
         */
        public bool Immune();
    }
}
