using Project1.Enemy;
using Project1.Interfaces;

namespace Project1.Commands
{
    class EnemyTakeDamageCommand : ICommand
    {
        IEnemy enemy;
        int amount = 2; // default amount

        public EnemyTakeDamageCommand(IEnemy enemy, int amount)
        {
            this.enemy = enemy;
            this.amount = amount;
        }

        public EnemyTakeDamageCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void Execute()
        {
            enemy.TakeDamage(amount);
            // because enemy change direction base on current direction state, so it won't change to the same direction it's moving
            enemy.ChangeDirection();
        }
    }
}
