using Project1.Interfaces;

namespace Project1.Enemy
{
    public interface IEnemy : IGameObject
    {
        public IEnemyState State { get; set; }
        public ISprite Sprite { get; set; }
        public float MovingSpeed { get; set; }
        public void FireBallAttack();
        public void BoomerangAttack();
        public void ChangeDirection();
        public void TakeDamage(int damage);

    }
}
