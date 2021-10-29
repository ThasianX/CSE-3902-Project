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

        public void Execute()
        {
            enemy.TakeDamage(amount);
        }
    }
}
