using Project1.Interfaces;

namespace Project1.Enemy
{
    public interface IEnemy : IGameObject
    {
        public IEnemyState state { get; set; }
        public ISprite sprite { get; set; }
        public float movingSpeed { get; set; }
        public void FireBallAttack();
        public void BoomerangAttack();
        public void ChangeDirection();
        public void TakeDamage(int damage);

    }
}
