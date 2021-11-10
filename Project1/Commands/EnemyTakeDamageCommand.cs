using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.Commands
{
    class EnemyTakeDamageCommand : ICommand
    {
        IEnemy enemy;
        int amount = 1; // default amount
        private bool takeDamage = true;

        public EnemyTakeDamageCommand(IEnemy enemy, int amount)
        {
            this.enemy = enemy;
            this.amount = amount;
        }

        public EnemyTakeDamageCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public EnemyTakeDamageCommand(IEnemy enemy, IProjectile projectile)
        {
            this.enemy = enemy;
            if (projectile.Owner is IEnemy)
            {
                takeDamage = false;
            }
        }

        public void Execute()
        {
            if (takeDamage)
            {
                enemy.TakeDamage(amount);
            }
        }
    }
}
