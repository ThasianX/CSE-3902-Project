using Project1.Enemy;
using Project1.GameStates;
using Project1.Interfaces;
using Project1.Levels;
using Project1.Objects.Effects;

namespace Project1
{
    public class GameObjectDeletionManager
    {
        private static GameObjectDeletionManager instance = new GameObjectDeletionManager();

        public static GameObjectDeletionManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void EnemyDeletionCheck(IEnemy enemy, IHealthState enemyHealth)
        {
            if (enemyHealth.health <= 0)
            {
                LevelManager.Instance.GetCurrentRoom().RemoveObject(enemy);
                GameObjectManager.Instance.AddOnNextFrame(new Poof(enemy.Position));
                GameObjectManager.Instance.RemoveOnNextFrame(enemy);
                Loot.RandomLoot(enemy.LootTable, enemy.Position);
            }
        }
    }
}
